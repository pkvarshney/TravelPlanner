namespace TravelPlanner.Models
{
    public class TransportFare
    {
        public int id { get; set; }
        public int TransportId { get; set; }
        public DateTime TravelDate { get; set; }
        public double Fare { get; set; }
        public int DestinationId { get; set; }

    }
}
