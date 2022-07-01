using CustomTxtParser.Services.Abstraction;
using CustomTxtParser.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.RepositoryServices.Abstraction;
using Repository.RepositoryServices.Implementation;

namespace CustomTxtParser.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddRepository(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services
                .AddScoped<IUnitOfWork, UnitOfWork>();
            return builder;
        }

        public static WebApplicationBuilder AddAppDbContext
            (this WebApplicationBuilder builder,IConfiguration configuration)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"), 
                    builder =>
                {
                    builder.MigrationsAssembly(nameof(Repository));
                });
            });
            return builder;
        }

        public static WebApplicationBuilder AddCustomServices(this WebApplicationBuilder builder)
        {
            builder.Services
               .AddScoped<IRuntimeServices, RuntimeServices>();
            builder.Services
             .AddScoped<ITxtParserServices, TxtParserServices>();
            builder.Services
            .AddScoped<ITransactionServices, TransactionServices>();
            return builder;
        }
    }
}
