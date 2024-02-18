using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Configuration.Mapper;
using TimeTracker.Models;
using System.Xml.Serialization;
using TimeTracker.Api;
using Microsoft.OpenApi.Writers;
using TimeTracker.Helpers;

namespace TimeTracker
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            var app = BuildApp(args);
            AddMiddleware(app);

            using(var score = app.Services.CreateScope())
            {
                var apis = score.ServiceProvider.GetServices<BaseApi>();
                foreach (var api in apis)
                {
                    api.Registr(app);
                }

                app.Run();
            }
           
        }

        private static WebApplication BuildApp(params string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AddServices(builder);        

            var app = builder.Build();
           // app.UseAuthorization();
            return app;
        }

        private static void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(CustomerProfile));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLogging();
            builder.Services.RegistrApi();
        }

        private static void AddMiddleware(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}