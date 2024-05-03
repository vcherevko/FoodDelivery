using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodDelivery.Data;

public static class MigrationManager
{
	public static void ApplyMigration(this IServiceProvider app)
	{
		try
		{
			using var scope = app.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

			if (dbContext.Database.GetPendingMigrations().Any())
			{
				dbContext.Database.Migrate();
			}
		}
		catch (Exception e)
		{
			// Log errors or do anything that is needed
			Console.WriteLine(e);
			throw;
		}
	}
}
