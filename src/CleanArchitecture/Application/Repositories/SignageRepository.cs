using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Interface;

namespace CleanArchitecture.Application.Repositories;

public class SignageRepository(ApplicationDbContext context) : GenericRepository<Signage>(context), ISignageRepository
{
}
