using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Airbus, Boeing }
    public class Plane
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public DateTime MenuFactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType Type{get; set; }

        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "Capacité: "+Capacity+ "MenuFactureDate"+ MenuFactureDate;
        }
        public Plane()
        { }


        public Plane(int capacity, DateTime menuFactureDate)
        {
            Capacity = capacity;
            MenuFactureDate = menuFactureDate;


        }
    }

    }
