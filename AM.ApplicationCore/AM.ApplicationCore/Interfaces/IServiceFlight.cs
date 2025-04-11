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

        // Vols ordonnés par date de départ des n derniers avions
        IEnumerable<Flight> GetFlightsOrderedByDeparture(int n);

        // Vérification de disponibilité de places
        bool CanReserveNSeats(Flight flight, int n);

        // Suppression des avions de plus de 10 ans
        void DeletePlanesOlderThan10Years();

        // Staff d'un vol spécifique
        IEnumerable<Staff> GetStaffOfFlight(int flightId);
    }
}
