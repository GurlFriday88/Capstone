using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Prefix
    {

        public int ID { get; set; }

        
        public string Name { get; set; }

        public virtual Provider Provider { get; set; }

        public int ProviderID { get; set; }




    }
}
