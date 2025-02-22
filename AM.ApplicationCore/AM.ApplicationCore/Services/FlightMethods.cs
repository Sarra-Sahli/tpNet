using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods
    {


        public List<Flight> Flights { get; set; } = new List<Flight>();
        //DELEGEUE
        public Action<Plane> FlightDetailsD;
        public Func <string, double> DurationAverageDel;

        public FlightMethods()
        {
            //FlightDetailsD = ShowFlightDetails;
            FlightDetailsD= de => {
                
                    Flights.Where(f => f.Plane == de)
                                     .Select(f => new { f.FlightDate, f.Destination });
                };


            
        // DurationAverageDel = DurationAverage;
        DurationAverageDel = da =>
    {
        return Flights.Where(f => f.Destination == da)
                  .Average(f => f.EstimatedDuration);
    };


}

public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();
            // o fama for zeda b boucle for addya

            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    flightDates.Add(flight.FlightDate);
                }

            }
            return flightDates;


        }
        public void ShowFlightDetails(Plane plane)
        {
            var flightDetails = Flights
                .Where(f => f.Plane == plane)
                .Select(f => new { f.FlightDate, f.Destination });

            foreach (var flight in flightDetails)
            {
                Console.WriteLine($"Date: {flight.FlightDate}, Destination: {flight.Destination}");
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var querry = from f in Flights where f.FlightDate == startDate.AddDays(7)
                         select f;
            return querry.Count();
        }
        public double DurationAverage(string destination)
        {
            return Flights.Where(f => f.Destination == destination).Select(f => f.EstimatedDuration).Average();
        }
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            return from f in Flights
                   orderby f.EstimatedDuration descending
                   select f;
        }
        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            return flight.Passengers.OfType<Traveller>().OrderByDescending(p => p.BirthDate).Take(3).ToList();

        }
        public IEnumerable<IGrouping<string, Flight>>DestinationGroupedFlight()
            {
            var req = Flights.GroupBy(f => f.Destination);
            foreach (var f in req)
            {
                Console.WriteLine("Destination"+ f.Key);
                foreach (var d in f)
                {
                    Console.WriteLine("Décollage"+ d.FlightDate);
            }
            }
            return req;
                
                }
       
    }
}
