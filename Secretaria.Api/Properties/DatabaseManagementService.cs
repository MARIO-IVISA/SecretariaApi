using Microsoft.EntityFrameworkCore;
using Secretaria.Infrastructure.Context;

namespace Secretaria.Api.Properties
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialisation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<SqlServerContext>();
                context.Database.Migrate();
            }
        }
    }
}
