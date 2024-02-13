using BLL.Models;

namespace BLL.Services
{
    public interface ITrackerService
    {
        TrackerDTO Get(int id);
        IEnumerable<TrackerDTO> GetAll();
        bool Delete(int id);
        void Add(TrackerDTO tracker);
        void Update(TrackerDTO tracker);
    }
}
