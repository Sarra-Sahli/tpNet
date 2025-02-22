using System;
using System.Collections.Generic;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; } // Correction du type
        public DateTime FlightDate { get; set; }
        public string AirlineLogo { get; set; }
        
        public int PlaneFK { get; set; }
        public Plane Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>(); // Initialisation pour éviter NullReferenceException

        public override string ToString()
        {
            return $"Flight to {Destination} on {FlightDate} (Duration: {EstimatedDuration} min)";
        }
      
    }
}
