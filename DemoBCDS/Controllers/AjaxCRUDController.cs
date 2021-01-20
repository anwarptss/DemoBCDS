using DemoBCDS.DAL;
using DemoBCDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoBCDS.Controllers
{
    public class AjaxCRUDController : Controller
    {
        DbContext db = new DbContext();
        // GET: AjaxCRUD
        public ActionResult Index()
        {
            return View();
        }


        //Json Methods
        public JsonResult EmpList()
        {            
            return Json(db.employeeList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddEmployee(EmployeeModel data)
        {
            db.addEmployee(data);
            return Json("success",JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateEmployee(EmployeeModel data)
        {
            db.updateEmployee(data);
            return Json("Success",JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByEmpId(int Id)
        {
            return Json(db.empFindById(Id),JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteEmployee(int Id)
        {
            db.deleteEmployee(Id);
            return Json("success",JsonRequestBehavior.AllowGet);
        }
    }
}