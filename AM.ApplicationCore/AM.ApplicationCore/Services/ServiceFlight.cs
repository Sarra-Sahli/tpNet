using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        protected readonly IUnitOfWork _unitOfWork; // Changé de private à protected

        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Staff> GetAllstaffByid(int id)
        {
            return GetById(id).Tickets.Select(p=>p.Passenger).OfType<Staff>().ToList();
}

        public IEnumerable<Flight> GetFlightsOrderedByDeparture(int n)
        {
            return _unitOfWork.Repository<Flight>().GetAll()
                .OrderByDescending(f => f.Departure)
                .Take(n);
        }


        public bool NbPlaceDisponible(Flight f, int n)
        {
            int capacity = f.Plane.Capacity;
            int nbPassengers = f.Tickets.Count;
            return capacity >= (nbPassengers + n);


        }

    }
}
