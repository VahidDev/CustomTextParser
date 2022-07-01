using Microsoft.EntityFrameworkCore;
using Repository.DAL;

namespace CustomTxtParser.Extensions
{
    public static class WebApplicationExtension
    {
        public static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using(IServiceScope scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }
            return app;
        }
    }
}
