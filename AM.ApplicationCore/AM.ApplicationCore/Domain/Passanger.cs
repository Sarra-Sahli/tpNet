using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string TelNumber { get; set; }

        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "BirthDate: " + BirthDate + "EmailAddress" + EmailAddress+ "FirstName"+ FirstName+"LastName"+ LastName+ "PassportNumber"+PassportNumber+ "TelNumber"+ TelNumber;
        }
      
        public bool CheckProfile(string firstname, string lastname, string email)
        {
            if (email == null)
            {

                return FirstName == firstname && LastName == lastname && EmailAddress==email;
            }
            else
            {
                return FirstName == firstname && LastName == lastname;
            }

        } 
        //on a jouter virtal pour que la calsse fille peut etre herité
        public virtual void PassengerType()
        {
            Console.WriteLine("Im a passenger");
        }
    }
}
