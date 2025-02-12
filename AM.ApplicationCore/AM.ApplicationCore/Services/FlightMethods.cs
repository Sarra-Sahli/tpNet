using System;
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

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();
            // o fama for zeda b boucle for addya

            foreach  (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    flightDates.Add(flight.FlightDate);
                }
               
            }
            return flightDates;


        }

    }
}
