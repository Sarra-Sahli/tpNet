using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePassenger 
    {

        // Retourner les voyageurs d'un avion passé en paramètre
        IEnumerable<Passenger> GetPassengersByPlane(Plane plane);

        // Retourner la liste des voyageurs qui ont voyagé dans un avion donné à une date donnée
        IEnumerable<Passenger> GetPassengersByPlaneAndDate(Plane plane, DateTime date);

        // Afficher le nombre de voyageurs par date de vol entre deux dates données
        void ShowPassengerCountByFlightDate(DateTime startDate, DateTime endDate);
    }
}
