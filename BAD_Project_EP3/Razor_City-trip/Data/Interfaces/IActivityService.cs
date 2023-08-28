using Razor_City_trip.Data.Model;

namespace Razor_City_trip.Data.Interfaces
{
    public interface IActivityService
    {
        List<Activity> GetActivitiesOfItinerary(int id);
        int GetActivity(int id);
        void SetActivity(Activity activity);
        void DeleteActivity(int id);
    }
}
