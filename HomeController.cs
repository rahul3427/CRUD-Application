using finalCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalCRUD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            employeedb obj = new employeedb();
            List<employees> empList = obj.GetEmployees();
            return View(empList);
        }
        public ActionResult create()
        {
            ado_dbEntities3 db=new ado_dbEntities3();
            List<CityName> emp=db.CityNames.ToList();
            ViewBag.employeetbl = new SelectList(emp, "City", "City");
            var age = new List<string>() { "Male", "Female"};
            ViewBag.age = age;
            return View();
        }
        [HttpPost]
        public ActionResult create(employees emp)
        {
            if (ModelState.IsValid)
            {
                employeedb employeedb = new employeedb();
                bool check =employeedb.addEmployee(emp);
                if (check)
                {
                    TempData["insert"] = "Data Inserted Successfully...";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();  
        }
        public ActionResult edit(int id) { 
            employeedb employeedb=new employeedb();
            var row = employeedb.GetEmployees().Find(model => model.id == id);

            return View(row);
        }
        [HttpPost]
        public ActionResult edit(int id,employees emp)
        {
            if (ModelState.IsValid)
            {
                employeedb employeedb = new employeedb();
                bool check = employeedb.editEmployee(emp);
                if (check)
                {
                    TempData["update"] = "Data Updated Successfully...";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();

        }
        public ActionResult delete(int id)
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult delete(int id, employees emp)
        {
                employeedb employeedb = new employeedb();
                bool check = employeedb.deleteEmployee(emp);
                if (check)
                {
                    TempData["delete"] = "Data Deleted Successfully...";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            
            return View();

        }

    }
}