using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight : IService<Flight>
    {
        public IEnumerable<Flight> GetFlightsOrderedByDeparture(int n);
        public bool NbPlaceDisponible(Flight f, int n);
        public IList<Staff> GetAllstaffByid(int id);

    }
}
