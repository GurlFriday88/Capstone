using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Store
    {
        public int ID { get; set; }

        
        public String Name { get; set; }

        public virtual Contact Contact { get; set; }




    }
}
