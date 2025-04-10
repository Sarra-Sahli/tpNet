using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MinLength(3, ErrorMessage = "langueur moin de 3 caratctere")]
        [MaxLength(25, ErrorMessage = "Langeure plus de 25 caratctere")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
