namespace TravelPlanner.Entities
{
    public class TravelRequest
    {
        public DateTime TravelDate { get; set; }
        public double Budget { get; set; }
        public int[] PreferredDestinationIds { get; set; }
        public int TransportId { get; set; }
        public double Distance { get; set; }
        public int[] Activities { get; set; }

    }
}
