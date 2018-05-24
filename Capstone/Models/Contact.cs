﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Contact
    {
        public int ID { get; set; }


        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public Store Store { get; set; }

        public Provider Provider { get; set; }
    }
}
