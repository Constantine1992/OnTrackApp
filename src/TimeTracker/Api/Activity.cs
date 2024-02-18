
using AutoMapper;
using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Models;

namespace TimeTracker.Api
{
    public class Activity : BaseApi
    {
        private readonly IActivityService _service;
        private readonly IMapper _mapper;

        public Activity(ILogger<BaseApi> logger, IMapper mapper, IActivityService service)
        {
            _service = service;
            _mapper = mapper;
            Logger = logger;
        }

        public override void Registr(WebApplication app)
        {
            app.MapGet("/", (HttpContext context) =>
            {
                return  _service.GetAll();
            });

            app.MapGet("/{id}", (int id) => {
                return _service.Get(id);
            });

            app.MapPost("/", (HttpContext context, [FromBody] Tracker tracker) => {

                var maps = _mapper.Map<TrackerDTO>(tracker);

                _service.Add(_mapper.Map<Tracker, TrackerDTO>(tracker));
            });

            app.MapDelete("/{id}", (int id) => {
                _service.Delete(id);
            });

        }
    }
}
