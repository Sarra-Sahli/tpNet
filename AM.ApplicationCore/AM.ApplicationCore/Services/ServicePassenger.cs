using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePassenger : Service<Passenger>, IServicePassenger

    {
        protected readonly IUnitOfWork _unitOfWork; // Changé de private à protected

        public ServicePassenger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IEnumerable<Passenger> GetPassengersByPlane(Plane plane)
        {
            return _unitOfWork.Repository<Flight>().GetAll()
                .Where(f => f.Plane == plane)
                .SelectMany(f => f.Passengers)
                .Distinct();
        }

       

        public void ShowPassengerCountByFlightDate(DateTime startDate, DateTime endDate)
        {
            var passengerCounts = _unitOfWork.Repository<Flight>().GetAll()
                .Where(f => f.FlightDate >= startDate && f.FlightDate <= endDate)
                .GroupBy(f => f.FlightDate.Date)
                .Select(g => new {
                    Date = g.Key,
                    PassengerCount = g.Sum(f => f.Passengers.Count)
                })
                .OrderBy(x => x.Date);

            foreach (var item in passengerCounts)
            {
                Console.WriteLine($"Date: {item.Date.ToShortDateString()}, Nombre de passagers: {item.PassengerCount}");
            }
        }
        public IList<Passenger> GetPassengersByPlaneAndDate(Plane plane, DateTime date)
        {
            return GetById(plane.PlaneId).Flights.Where(f => f.FlightDate == date)
                .SelectMany(t=>t.Tickets.Select(p=>p.Passenger))
                .ToList();
          }


    }
}

