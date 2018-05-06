using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Provider
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string SubscriberNumber { get; set; }

        public int PagesToSave { get; set; }

        public string SavedPagesDescription { get; set; }

        public string BenefitRenewal { get; set; }

        public string AuthNote { get; set; }

        public string MiscNotes { get; set; }

        //Foreign Keys for patient and prefixes 

        public IList<Patient> PatientType { get; set; }

        public BcbsPrefix BcbsPrefix { get; set; }

        public IList<BcbsPrefix> BcbsPrefixes { get; set; }
    }
}
