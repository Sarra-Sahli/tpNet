using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {  
        public string Pilet { get; set; }
        public int FlightId { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; } // Correction du type
        public DateTime FlightDate { get; set; }
        public string AirlineLogo { get; set; }
        [ForeignKey(nameof(PlaneFK))]
        public int PlaneFK { get; set; }
        public Plane Plane { get; set; }
        public ICollection<Tickets> Tickets { get; set; }

        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>(); // Initialisation pour éviter NullReferenceException

        public override string ToString()
        {
            return $"Flight to {Destination} on {FlightDate} (Duration: {EstimatedDuration} min)";
        }
      
    }
}
