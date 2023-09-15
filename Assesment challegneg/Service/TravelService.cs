using TravelPlanner.Entities;
using TravelPlanner.Models;

namespace TravelPlanner.Service
{
    public class TravelService : ITravelService
    {
        public TravelItineraryResponse GetTravelItineraries(TravelRequest request)
        {
            var resp = new TravelItineraryResponse();

            var destinations = new List<Destinations>();
            var TransportFare = new List<TransportFare>();
            var Transport = new List<Transportation>();

            // Suggestions as per User Preferences
            var feasibleDestinations = destinations.Where(k => request.PreferredDestinationIds.Contains(k.id) && k.accomodationExpenses < request.Budget).Select(k => new ExpenseInfo
            {
                DestinationId = k.id,
                AccomodationExpense = k.accomodationExpenses,
                RemainingBudget = request.Budget - k.accomodationExpenses
            });

            foreach (var Dest in feasibleDestinations)
            {
                var feasibletravel = TransportFare.FirstOrDefault(k => k.TravelDate == request.TravelDate && k.TransportId == request.TransportId && k.Fare * request.Distance <= Dest.RemainingBudget);
                if (feasibletravel != null)
                {
                    Dest.TransportId = feasibletravel.TransportId;
                    Dest.TravelExpense = feasibletravel.Fare;
                    Dest.TravelDate = feasibletravel.TravelDate;
                    Dest.isFeasible = true;
                }
                else
                    Dest.isFeasible = false;
            }

            resp.FeasiblePreferredDestination = feasibleDestinations.Where(K => K.isFeasible).Select(k => new TravelItineraryInfo
            {
                Destination = destinations.FirstOrDefault(j => j.id == k.DestinationId)?.DestinationName,
                TotalExpenses = k.TravelExpense = k.AccomodationExpense,
                Transport = Transport.FirstOrDefault(j => j.id == k.TransportId)?.TransportName
            });


            // Other Suggestions
            if (!feasibleDestinations.Any())
            {
                var otherDestinations = destinations.Where(k => k.accomodationExpenses < request.Budget).Select(k => new ExpenseInfo
                {
                    DestinationId = k.id,
                    AccomodationExpense = k.accomodationExpenses,
                    RemainingBudget = request.Budget - k.accomodationExpenses
                });

                foreach (var Dest in otherDestinations)
                {
                    var feasibletravel = TransportFare.FirstOrDefault(k => k.TransportId == request.TransportId && k.Fare * request.Distance <= Dest.RemainingBudget);
                    if (feasibletravel != null)
                    {
                        Dest.TransportId = feasibletravel.TransportId;
                        Dest.TravelExpense = feasibletravel.Fare;
                        Dest.TravelDate = feasibletravel.TravelDate;
                        Dest.isFeasible = true;
                    }
                    else
                        Dest.isFeasible = false;
                }

                resp.AlternateSuggestions = otherDestinations.Where(K => K.isFeasible).Select(k => new TravelItineraryInfo
                {
                    Destination = destinations.FirstOrDefault(j => j.id == k.DestinationId)?.DestinationName,
                    TotalExpenses = k.TravelExpense = k.AccomodationExpense,
                    Transport = Transport.FirstOrDefault(j => j.id == k.TransportId)?.TransportName
                });
            }

            return resp;
        }

    }
}
