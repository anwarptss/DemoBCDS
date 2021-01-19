using DemoBCDS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DemoBCDS.DAL
{
    public class DbContext
    {
        BCDS_DemoEntities db = new BCDS_DemoEntities();

        public void addEmployee(EmployeeModel data)
        {
            tblEmployee emp = new tblEmployee()
            {
                EmpAge = data.EmpAge,
                EmpName = data.EmpName,
                EmpPhone =data.EmpPhone,
                Password = data.Password,
                ConfirmPassword =data.ConfirmPassword
            };
            db.tblEmployees.Add(emp);
            db.SaveChanges();
        }
        public List<EmployeeModel> employeeList()
        {
            return db.tblEmployees.Select(x => new EmployeeModel()
            {
                Id=x.Id.ToString(),
                EmpName = x.EmpName,
                EmpAge = x.EmpAge,
                EmpPhone = x.EmpPhone,
                Password = x.Password,
                ConfirmPassword = x.ConfirmPassword
            }).ToList();
        }
        public EmployeeModel empFindById(int id)
        {
            return db.tblEmployees.Where(s => s.Id == id).Select(x => new EmployeeModel()
            {

                EmpName = x.EmpName,
                EmpAge = x.EmpAge,
                EmpPhone = x.EmpPhone,
                Password = x.Password,
                ConfirmPassword = x.ConfirmPassword
            }).FirstOrDefault();
        }

        public void updateEmployee(EmployeeModel data)
        {
            int id = Convert.ToInt32(data.Id);
            var emp = db.tblEmployees.Where(x=>x.Id==id).FirstOrDefault();

            emp.EmpName = data.EmpName;
            emp.EmpAge = data.EmpAge;
            emp.EmpPhone = data.EmpPhone;
            emp.Password = data.Password;
            emp.ConfirmPassword = data.ConfirmPassword;
            db.SaveChanges();
        }

        public void deleteEmployee(EmployeeModel data)
        {
            int id = Convert.ToInt32(data.Id);
            var emp = db.tblEmployees.Where(x => x.Id == id).FirstOrDefault();
            db.Entry(emp).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}