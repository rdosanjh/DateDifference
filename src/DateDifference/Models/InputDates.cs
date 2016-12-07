using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DateDifference.Models
{
    public class DatesViewModel
    {
        [DisplayName("Date One")]
        public string DateOne { get;set; }
        [DisplayName("Date Two")]
        public string DateTwo { get; set; }

        public int? Result;
    }
}
