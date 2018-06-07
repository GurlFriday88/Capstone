using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Provider
    {
       
        [Key]
        public int ProviderID { get; set; }

        [ForeignKey("Prefix")]
        public int PrefixID { get; set; }
        public virtual Prefix Prefix { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }

        public virtual List<Prefix> Prefixes { get; set; }
        public virtual List<Patient> Patients { get; set; }

        [Required(ErrorMessage ="Enter A Name For Your Provider")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public string EligibilityExpiry { get; set; }

        public string Plan { get; set; }


        public string SubscriberNumber { get; set; }

        [RegularExpression(@"^[0-9]$", ErrorMessage = "Enter A Number Between 1-10")]
        public int PagesToSave { get; set; }

        public string SavedPagesDescription { get; set; }

        public string BenefitRenewal { get; set; }

        public string AuthNote { get; set; }

        public string MiscNotes { get; set; }

        

    }
}
