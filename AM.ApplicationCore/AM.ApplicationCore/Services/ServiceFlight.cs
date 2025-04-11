using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    internal class ServiceFlight : Service<Flight>, IServiceFlight
    {
        protected readonly IUnitOfWork _unitOfWork; // Changé de private à protected

        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Flight> GetFlightsOrderedByDeparture(int n)
        {
            return _unitOfWork.Repository<Flight>().GetAll()
                .OrderByDescending(f => f.Departure)
                .Take(n);
        }

        public bool CanReserveNSeats(Flight flight, int n)
        {
            var currentPassengers = _unitOfWork.Repository<Flight>()
                .GetById(flight.FlightId)?.Passengers.Count ?? 0;
            return flight.Plane.Capacity - currentPassengers >= n;
        }

        public void DeletePlanesOlderThan10Years()
        {
            var thresholdDate = DateTime.Now.AddYears(-10);
            var oldPlanes = _unitOfWork.Repository<Plane>().GetAll()
                .Where(p => p.ManufactureDate < thresholdDate)
                .ToList();

            foreach (var plane in oldPlanes)
            {
                _unitOfWork.Repository<Plane>().Delete(plane);
            }
            _unitOfWork.Commit();
        }

        public IEnumerable<Staff> GetStaffOfFlight(int flightId)
        {
            return _unitOfWork.Repository<Flight>().GetById(flightId)?
                   ?? Enumerable.Empty<Staff>();
        }
    }
}
