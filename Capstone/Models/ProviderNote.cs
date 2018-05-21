using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class ProviderNote
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


        public virtual Provider Provider { get; set; }

        public virtual Contact Contact { get; set; }

        public IEnumerable<Patient> Patients { get; set; }


    }
}