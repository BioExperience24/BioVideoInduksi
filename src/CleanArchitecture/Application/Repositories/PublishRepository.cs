using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Interface;

namespace CleanArchitecture.Application.Repositories;

public class PublishRepository(ApplicationDbContext context) : GenericRepository<Publish>(context), IPublishRepository
{
}
