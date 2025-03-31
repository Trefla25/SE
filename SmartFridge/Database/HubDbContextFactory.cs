using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFridge.Database;

public class HubDbContextFactory
{
    private readonly IServiceProvider _serviceProvider;

    public HubDbContextFactory()
    {
        var services = new ServiceCollection();

        // Register both DbContexts
        services.AddDbContext<SmartFridgeDbContext>(options =>
            options.UseSqlite("Data Source=smartfridge.db"));

        services.AddDbContext<UserIngredientsDbContext>(options =>
            options.UseSqlite("Data Source=useringredients.db"));

        _serviceProvider = services.BuildServiceProvider();
    }

    public SmartFridgeDbContext CreateSmartFridgeDbContext()
    {
        var dbContext = _serviceProvider.GetRequiredService<SmartFridgeDbContext>();
        dbContext.Database.EnsureCreated(); 
        return dbContext;
    }

    public UserIngredientsDbContext CreateUserIngredientsDbContext()
    {
        var dbContext = _serviceProvider.GetRequiredService<UserIngredientsDbContext>();
        dbContext.Database.EnsureCreated();
        return dbContext;
    }
}
