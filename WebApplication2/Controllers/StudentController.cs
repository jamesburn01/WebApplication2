using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.DataContext;

namespace WebApplication2.Controllers
{


    public class StudentController : Controller
    {
        DataLayer _DataContext = new DataLayer();
        // GET: Student
        public ActionResult Index()
        {
            try
            
            {
                return View(_DataContext.students.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}