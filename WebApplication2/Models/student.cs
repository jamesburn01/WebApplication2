﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{

    [Table("student", Schema = "public")]
    public class student
    {
        [Key]
        public int stid { get; set; }
        public string name { get; set; }
    }
}