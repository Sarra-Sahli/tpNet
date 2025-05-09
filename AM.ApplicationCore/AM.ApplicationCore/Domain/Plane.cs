﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Airbus, Boeing }

    public class Plane
    {
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
      
        public DateTime ManufactureDate { get; set; } // Correction du nom
        public int PlaneId { get; set; }
        public PlaneType Type { get; set; }

        public ICollection<Flight> Flights { get; set; } = new List<Flight>(); // Initialisation pour éviter NullReferenceException

        public override string ToString()
        {
            return $"Capacité: {Capacity}, Manufacture Date: {ManufactureDate.ToShortDateString()}";
        }

        public Plane() { }

        public Plane(int capacity, DateTime manufactureDate)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
        }
    }
}
