using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Prefix
    {

        public int ID { get; set; }

        [ForeignKey("Provider")]
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }

        [Required(ErrorMessage = "Enter An Alpha Prefix!")]
        [Display(Name = "Prefix")]
        [RegularExpression(@"^([A-Z]{3,5})$", ErrorMessage = "Prefix MUST Be Capatilized AND Between 3-5 Letters Long!")]
        public string Name { get; set; }

       

        




    }
}
