using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        //classe fille heriste de passenger 
        public override void PassengerType()
        { 
            base.PassengerType();//pour l'appel de fct
            Console.WriteLine("Im a Saff Member");
        }
    }

}
