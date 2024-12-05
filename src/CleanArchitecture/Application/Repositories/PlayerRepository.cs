using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Interface;

namespace CleanArchitecture.Application.Repositories;

public class PlayerRepository(ApplicationDbContext context) : GenericRepository<Player>(context), IPlayerRepository
{
}
