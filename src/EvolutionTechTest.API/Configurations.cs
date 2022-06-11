using EvolutionTechTest.Infrastructure.Respositories.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EvolutionTechTest.API
{
    public static class Configurations
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<EvolutionTestContext>();
            //db.Database.Migrate();
            return app;
        }
    }
}
