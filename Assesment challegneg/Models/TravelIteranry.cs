namespace TravelPlanner.Models
{
    public class TravelItinerary
    {
        public int id { get; set; }
        public DateTime TravelDate { get; set; }
        public int PreferredDestinationId { get; set; }
        public double budget { get; set; }
        public int DestinationId { get; set; }
        public double TotalExpenses { get; set; }
        public int TransportId { get; set; }

    }
}
