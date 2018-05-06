using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class MemoChoice
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //foreign key

        public int AutoMemoID { get; set; }
      
    }
}
