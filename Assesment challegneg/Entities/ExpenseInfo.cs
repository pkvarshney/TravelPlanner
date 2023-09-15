namespace TravelPlanner.Entities
{
    public class ExpenseInfo
    {
        public int DestinationId { get; set; }
        public double AccomodationExpense { get; set; }
        public double RemainingBudget { get; set; }
        public int TransportId { get; set; }
        public DateTime TravelDate { get; set; }
        public double TravelExpense { get; set; }
        public bool isFeasible { get; set; }
    }
}
