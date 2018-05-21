using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Provider
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string SubscriberNumber { get; set; }

        [Range(0, 10)]
        public int PagesToSave { get; set; }

        public string SavedPagesDescription { get; set; }

        public string BenefitRenewal { get; set; }

        public string AuthNote { get; set; }

        public string MiscNotes { get; set; }

        public virtual Contact Contact { get; set; }


        public IEnumerable<Prefix> Prefixes { get; set; }


    }
}
