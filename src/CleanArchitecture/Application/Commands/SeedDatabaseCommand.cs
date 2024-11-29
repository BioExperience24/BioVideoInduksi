using CleanArchitecture.Infrastructure.Data;

public class SeedDatabaseCommand
{
    private readonly IServiceProvider _serviceProvider;

    public SeedDatabaseCommand(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ExecuteAsync()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
            await initializer.InitializeAsync();
        }
    }
}
