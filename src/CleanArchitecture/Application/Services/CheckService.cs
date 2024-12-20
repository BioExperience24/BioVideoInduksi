using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interfaces;
using System.Text.Json;

namespace CleanArchitecture.Application.Services;

public class CheckService : ICheckService
{
    private readonly IUnitOfWork _unitOfWork;

    public CheckService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<object> Show(string serial, CancellationToken token)
    {
        var player = await _unitOfWork.PlayerRepository.FirstOrDefaultAsync(x => x.Serial == serial);

        if (player == null)
        {
            return new
            {
                status = "error",
                message = "Data not found"
            };
        }

        var publish = await _unitOfWork.PublishRepository.FirstOrDefaultAsync(
            filter: p => p.Player.Serial == serial,
            include: query => query
                .Include(p => p.Player)
                .Include(p => p.Signage)
                .Include(p => p.Signage.Template)
        );

        var signageContent = JsonSerializer.Deserialize<Dictionary<string, object>>(publish.Signage.Content);
        var content1 = signageContent.ContainsKey("content1")
            ? signageContent["content1"]
            : null;

        var content2 = signageContent.ContainsKey("content2")
            ? signageContent["content2"]
            : null;

        // sebelum return update player Liveatnya terlebih dahulu
        player.PlayerLiveAt = DateTime.UtcNow;
        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.PlayerRepository.Update(player), token);

        return new
        {
            status = "success",
            collection = new[]
            {
                new
                {
                    serial = serial,
                    publish_id = publish.Id,
                    publish_signage = publish.Signage.Name,
                    publish_player = publish.Player.Name,
                    publish_is_alltime = 1,
                    publish_to_client = 1,
                    publish_date_start = publish.PublishDate?.ToString("yyyy-MM-dd") ?? "",
                    publish_date_end = "",
                    publish_time_start = publish.PublishDate?.ToString("HH:mm:ss") ?? "",
                    publish_time_end = "",
                    publish_userid = "",
                    publish_datetime = publish.PublishDate,
                    publish_status = 1,
                    player_name = publish.Player.Name,
                    player_user = "",
                    publish_groupuser = "",
                    template_id = publish.Signage.TemplateId,
                    signage_content = new
                    {
                        content1 = content1,
                        content2 = content2
                    }
                }
            }
        };
    }

}
