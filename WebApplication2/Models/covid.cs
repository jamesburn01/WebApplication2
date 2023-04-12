using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class covid
    {
            public string country { get; set; }
            public decimal confirmed { get; set; }
            public string recovered { get; set; }
            public string deaths { get; set; }
    }
}