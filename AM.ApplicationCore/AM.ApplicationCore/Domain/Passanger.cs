using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        [Display(Name ="Date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public FullName FullName { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
        public string TelNumber { get; set; }
        public ICollection<Tickets> Tickets { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "BirthDate: " + BirthDate + "EmailAddress" + EmailAddress+ "FirstName"+ FullName.FirstName + "LastName"+ FullName.LastName + "PassportNumber"+PassportNumber+ "TelNumber"+ TelNumber;
        }
      
        public bool CheckProfile(string firstname, string lastname, string email)
        {
            if (email == null)
            {

                return FullName.FirstName == firstname && FullName.LastName == lastname && EmailAddress==email;
            }
            else
            {
                return FullName.FirstName == firstname && FullName.LastName == lastname;
            }

        } 
        //on a jouter virtal pour que la calsse fille peut etre herité
        public virtual void PassengerType()
        {
            Console.WriteLine("Im a passenger");
        }

    }
}
