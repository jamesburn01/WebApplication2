using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace WebApplication2.Models
{
    [Table("copy_test", Schema = "public")]
    public class copytest
    {

        public string province { get; set; }
        public string country { get; set; }
        [Key]
        public string sno { get; set; }
        public string observationdate { get; set; }
        [Column("Last Update")]
        public string LastUpdate { get; set; }
        public string deaths { get; set; }
        public string recovered { get; set; }
        public float confirmed { get; set; }
    }
}