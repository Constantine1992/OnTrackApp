using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Configuration.Mapper;
using TimeTracker.Models;
using System.Xml.Serialization;

namespace TimeTracker
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            var app = BuildApp(args);
            AddMiddleware(app);

            app.MapGet("/", (HttpContext context, ITrackerService service) => {
                return service.GetAll();
            })
                .Produces<TrackerDTO>()
                .WithName("GetTrackers")
                .WithTags("getters");

            app.MapGet("/{id}", (int id, ITrackerService service) => {
                return service.Get(id);
            });

            app.MapPost("/", (HttpContext context, [FromBody]Tracker tracker, IMapper mapper, ITrackerService service) => {
 
                var maps = mapper.Map<TrackerDTO>(tracker);
      
                service.Add(mapper.Map<Tracker, TrackerDTO>(tracker));
            });

            app.MapDelete("/{id}", (int id, ITrackerService service) => {
                service.Delete(id);
            });

            app.Run();
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
            builder.Services.AddScoped<ITrackerService, TrackerService>();
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