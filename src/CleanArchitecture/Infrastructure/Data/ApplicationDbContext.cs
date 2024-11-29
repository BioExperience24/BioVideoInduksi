using System.Reflection;
using CleanArchitecture.Web.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    public DbSet<Media> Media { get; set; }

    public DbSet<Template> Templates { get; set; }

    public DbSet<Signage> Signages { get; set; }

    public DbSet<PlayerGroup> PlayerGroups { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Publish> Publishes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Seed();
    }
}
