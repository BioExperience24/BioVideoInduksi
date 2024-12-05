using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Interface;

namespace CleanArchitecture.Application.Repositories;

public class PlayerGroupRepository(ApplicationDbContext context) : GenericRepository<PlayerGroup>(context), IPlayerGroupRepository
{
}
