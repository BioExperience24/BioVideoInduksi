using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Interface;

namespace CleanArchitecture.Application.Repositories;

public class TemplateRepository(ApplicationDbContext context) : GenericRepository<Template>(context), ITemplateRepository
{
}
