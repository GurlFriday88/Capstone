using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Patient
    {   
        [Key]
        public int PatientID { get; set; }


        [ForeignKey("Provider")]
        public int ProviderID { get; set; }




        [Required(ErrorMessage = "Select Type Of Patient!")]
        [Display(Name = "Patient Type")]
        public string Type { get; set; }

        public string Frames { get; set; }

        public string Lenses { get; set; }

        public string Exam { get; set; }

       


    }
}
