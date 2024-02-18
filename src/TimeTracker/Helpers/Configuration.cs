using BLL.Services;
using TimeTracker.Api;

namespace TimeTracker.Helpers
{
    public static class Configuration
    {
        public static void RegistrApi(this IServiceCollection services)
        {
            services.AddScoped<IActivityService, ActivityService>();
            services.AddTransient<BaseApi, Activity>();
        }
    }
}
