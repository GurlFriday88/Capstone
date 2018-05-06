using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class BcbsPrefix
    {
        public int ID { get; set; }

        public string Prefix { get; set; }

        //Foreign Keys

        public int ProviderID { get; set; }

        public Provider Provider { get; set; }

    }
}
