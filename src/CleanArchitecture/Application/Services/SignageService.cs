using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Models.Signage;
using CleanArchitecture.Web.Requests;
using System.Text.Json;

namespace CleanArchitecture.Application.Services;

public class SignageService(IUnitOfWork unitOfWork) : ISignageService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Pagination<Signage>> GetAll(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.SignageRepository.ToPagination(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Name,
            ascending: true
        );

        return data;
    }

    public async Task<ApiCollection<Signage>> GetCollection(int pageIndex, int pageSize)
    {
        var data = await _unitOfWork.SignageRepository.ToAllResult(
            pageIndex: pageIndex,
            pageSize: pageSize,
            orderBy: x => x.Id,
            ascending: false,
            filter: x => x.DeletedAt == null,
            include: query => query.Include(x => x.Template)
        );

        return data;
    }

    public async Task<Signage> Get(int id)
    {
        return await _unitOfWork.SignageRepository.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Add(SignageRequestAdd request, CancellationToken token)
    {
        var template = await _unitOfWork.TemplateRepository.FirstOrDefaultAsync(x => x.Id == request.TemplateId);

        if (template == null) throw new Exception("Template not found");

        var signageContent = await GenerateSignageContent(request);
        string contentJson = JsonSerializer.Serialize(signageContent);

        var signage = new Signage
        {
            Name = request.Name,
            Content = contentJson,
            TemplateId = request.TemplateId
        };

        await _unitOfWork.ExecuteTransactionAsync(async () =>
        {
            await _unitOfWork.SignageRepository.AddAsync(signage);
        }, token);
    }

    public async Task Update(SignageRequestUpdate request, CancellationToken token)
    {
        var signage = await _unitOfWork.SignageRepository.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (signage == null) throw new Exception("Signage not found");

        var template = await _unitOfWork.TemplateRepository.FirstOrDefaultAsync(x => x.Id == request.TemplateId);

        if (template == null) throw new Exception("Template not found");

        var signageContent = await GenerateSignageContent(request);
        string contentJson = JsonSerializer.Serialize(signageContent);

        signage.Name = request.Name;
        signage.Content = contentJson;
        signage.TemplateId = request.TemplateId;

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.SignageRepository.Update(signage), token);
    }

    public async Task Delete(int id, CancellationToken token)
    {
        var data = await _unitOfWork.SignageRepository.FirstOrDefaultAsync(x => x.Id == id);

        await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.SignageRepository.Delete(data), token);
    }

    private async Task<object> GenerateSignageContent(SignageRequest request)
    {
        var content1 = new List<object>();

        foreach (var mediaId in request.MediaIds)
        {
            var media = await _unitOfWork.MediaRepository.FirstOrDefaultAsync(x => x.Id == mediaId);

            if (media == null) throw new Exception($"Media with ID {mediaId} not found");

            content1.Add(new
            {
                id = media.Id,
                name = media.Name,
                filename = media.Filename,
                path = media.Path,
                type = media.MediaType,
                duration = media.Duration
            });
        }

        // var content2 = new
        // {
        //     RunningText = request.RunningText,
        //     Color = request.TextColor,
        //     Type = "running_text",
        //     BgColor = request.BackgroundColor,
        //     Size = request.FontSize,
        //     Speed = request.TextSpeed,
        //     FontRotate = request.FontRotate,
        //     SignageScroll = request.SignageScroll
        // };

        return new
        {
            content1 = new
            {
                content = content1,
                type = "multimedia",
                option = new
                {
                    effect = "fade"
                }
            },
            content2 = new
            {
                content = request.RunningText,
                type = "running_text",
                option = new
                {
                    speed = request.TextSpeed,
                    color = request.TextColor,
                    bgcolor = request.BackgroundColor,
                    size = request.FontSize,
                    fontRotate = "0deg",
                    signageScroll = "Horizontal"
                }
            }
        };
    }
}
