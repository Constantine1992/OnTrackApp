using AutoMapper;
using BLL.Models;
using TimeTracker.Models;

namespace TimeTracker.Configuration.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Tracker, TrackerDTO>();
        }
    }
}
