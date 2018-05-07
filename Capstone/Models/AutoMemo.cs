using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class AutoMemo
    {
        public int ID { get; set; }


        public IList<MemoChoice> MemoChoices { get; set; }
    }
}
