using TravelPlanner.Entities;

namespace TravelPlanner.Service
{
    public interface ITravelService
    {
        TravelItineraryResponse GetTravelItineraries(TravelRequest request);
    }
}
