using Microsoft.EntityFrameworkCore.Diagnostics;

namespace VerticalSliceArchitecture.Common.Persistence;

public static class DependencyInjection
{
    public static void AddEfCore(this IServiceCollection services)
    {
        services.AddScoped<ISaveChangesInterceptor, EventPublisher>();

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.UseNpgsql(
                sp.GetRequiredService<IConfiguration>().GetConnectionString("todoDb"),
                npgsqlOptions =>
                {
                    npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                });

            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });
    }
}