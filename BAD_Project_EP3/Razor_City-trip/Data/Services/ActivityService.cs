using Razor_City_trip.Data.Interfaces;
using Razor_City_trip.Data.Model;

namespace Razor_City_trip.Data.Services
{
    public class ActivityService : IActivityService
    {
        private static AppDBContext dbContext;

        public ActivityService(AppDBContext context)
        {
            dbContext = context;
        }
        public List<Activity> GetActivitiesOfItinerary(int id) 
        { 
            return dbContext.Activities.Where(c => c.ItineraryId == id).ToList();
        }

        public int GetActivity(int id)
        {
            return dbContext.Activities.FirstOrDefault(c => c.Id == id).ItineraryId;
        }

        public void SetActivity(Activity activity)
        {
            dbContext.Activities.Add(activity);
            dbContext.SaveChanges();
        }

        public void DeleteActivity(int id) 
        {
            Activity activity = dbContext.Activities.Find(id);
            dbContext.Remove(activity);
            dbContext.SaveChanges();
        }
    }
}
