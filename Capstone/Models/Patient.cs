using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Patient
    {
        public int ID { get; set; }

        public string PatientType { get; set; }

        public string Exam { get; set; }

        public string  Frames { get; set; }

        public string Lens { get; set; }

        //foreign key to provider table
        public int ProviderID { get; set; }

    }
}
