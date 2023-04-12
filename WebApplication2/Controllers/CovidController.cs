using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DataContext;
using Npgsql;
using System.Configuration;

namespace WebApplication2.Controllers
{
    public class CovidController : Controller
    {
        private NpgsqlConnection connection;
        DataLayer _DataContext = new DataLayer();
       
        public ActionResult Index()
         {
           
            return View();
        }

        private static covid ReadCovid(NpgsqlDataReader reader)
        {
        
            string country = reader["country"] as string;
            decimal? confirmed = reader["confirmed"] as decimal?;
            string recovered = reader["recovered"] as string;
            string deaths = reader["deaths"] as string;

            covid covidresult = new covid
            {
                country = country,
                confirmed = confirmed.Value,
                recovered = recovered,
                deaths = deaths,
            };
            return covidresult;
        }
        [HttpGet]
        public ActionResult CovidData(string observation, int maxresult)
        {
            covid covidViewmodel = new covid();
            List<covid> covids = new List<covid>();
            string connString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            connection = new NpgsqlConnection(connString);
            connection.Open();
            
            string commandText = $"select country, max(confirmed) as confirmed, max(recovered) as recovered,max(deaths) as deaths from public.copy_test where observationdate = @observation group by country order by confirmed desc limit @maxresult";
            using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("observation", observation);
                cmd.Parameters.AddWithValue("maxresult", maxresult);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            covidViewmodel = ReadCovid(reader);
                            covids.Add(covidViewmodel);
                        }
                        reader.NextResult();
                    }

            };

            connection.Close();

           
            return PartialView("CovidData", covids.AsEnumerable());

        }


    }
}