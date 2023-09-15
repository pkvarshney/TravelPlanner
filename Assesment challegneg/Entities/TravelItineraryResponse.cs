namespace TravelPlanner.Entities
{
    public class TravelItineraryInfo
    {
        public string Destination { get; set; }
        public string Transport { get; set; }
        public double TotalExpenses { get; set; }

    }

    public class TravelItineraryResponse
    {
        public IEnumerable<TravelItineraryInfo> FeasiblePreferredDestination { get; set; }
        public IEnumerable<TravelItineraryInfo> AlternateSuggestions { get; set; }
    }
}
