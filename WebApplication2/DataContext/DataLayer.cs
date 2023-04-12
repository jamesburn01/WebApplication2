using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Npgsql;
using WebApplication2.Models;

namespace WebApplication2.DataContext
{
    public class DataLayer : DbContext
    {
        public DataLayer() : base("myconnection")
        {

        }
        public virtual DbSet<copytest> copytests { get; set; }
        public virtual DbSet<student> students { get; set; }
    }
}