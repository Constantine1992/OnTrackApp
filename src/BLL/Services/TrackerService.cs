using BLL.Models;

namespace BLL.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly List<TrackerDTO> _trackerList;
        public TrackerService()
        {
            _trackerList = new List<TrackerDTO>
            {
                new TrackerDTO { Id = 1, Name = "Tracker1", Time = 5 },
                new TrackerDTO { Id = 2, Name = "Tracker2", Time = 8 },
            };
        }

        public void Add(TrackerDTO tracker)
        {
            if(tracker is null)
                throw new ArgumentNullException(nameof(tracker));

            _trackerList.Add(tracker);
        }

        public bool Delete(int id)
        {
            var deletedTracker = _trackerList.FirstOrDefault(x => x.Id == id);

            if (deletedTracker is null)
                throw new Exception($"Not found by id: {id}");

            return _trackerList.Remove(deletedTracker);
        }

        public TrackerDTO Get(int id)
        {
            var tracker = _trackerList.FirstOrDefault(x => x.Id == id);

            if (tracker is null)
                throw new Exception($"Trackers {id} not found");

            return tracker;
        }

        public IEnumerable<TrackerDTO> GetAll()
        {
            return _trackerList;
        }

        public void Update(TrackerDTO tracker)
        {
            throw new NotImplementedException();
        }
    }
}
