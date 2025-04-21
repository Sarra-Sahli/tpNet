using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane :  Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Flight> GetFlight(int n)
        {
            return GetAll().OrderByDescending(p => p.PlaneId)
                .SelectMany(p => p.Flights).
                OrderBy(f => f.FlightDate).Take(n).ToList();
        }
    }
}
