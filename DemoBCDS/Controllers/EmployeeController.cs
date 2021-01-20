using DemoBCDS.DAL;
using DemoBCDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBCDS.Controllers
{
    public class EmployeeController : Controller
    {
        DbContext db = new DbContext();
        // GET: Employee
        public ActionResult Index()
        {            
            return View(db.employeeList());
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(EmployeeModel data)
        {
            db.addEmployee(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {            
            return View(db.empFindById(id));
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeeModel data)
        {
            db.updateEmployee(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            return View(db.empFindById(id));
        }
        [HttpPost]
        public ActionResult DeleteEmployee(EmployeeModel data)
        {
            db.deleteEmployee(Convert.ToInt32(data.Id));
            return RedirectToAction("Index");
        }

    }
}