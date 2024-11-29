using CleanArchitecture.Application.Common.Utilities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data;
/// <summary>
/// Another way to seed data use DbContext
/// </summary>
public class ApplicationDbContextInitializer(ApplicationDbContext context, ILoggerFactory logger)
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger _logger = logger.CreateLogger<ApplicationDbContextInitializer>();

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
            await SeedUser();
        }
        catch (Exception exception)
        {
            _logger.LogError("Migration error {exception}", exception);
            throw;
        }
    }

    public async Task SeedUser()
    {
        // Periksa apakah sudah ada pengguna dengan email 'admin@gmail.com'
        var existingUser = await _context
                        .Users
                        .FirstOrDefaultAsync(u => u.Email == "admin@gmail.com");

        // Jika tidak ada, tambahkan pengguna baru
        if (existingUser == null)
        {
            await _context.Users.AddRangeAsync(
            new List<User>
            {
            new User
            {
                Name = "Admin",
                Email = "admin@gmail.com",
                UserName = "admin",
                Role = Role.Admin,
                Password = "P@ssw0rd".Hash(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
            });

            // Simpan perubahan ke database
            await _context.SaveChangesAsync();
        }
    }

}
