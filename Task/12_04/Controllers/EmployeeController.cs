using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _12_04.Business;
using _12_04.ControllerLogic;
using _12_04.Entities;
using _12_04.Models;

namespace _12_04.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        EmployeeBusiness objEmployeeBusiness = new EmployeeBusiness();
        public ActionResult Add(int? StateId, int? DistrictId)
        {
            Employee ObjEmployee = new Employee();

            ObjEmployee.States = objEmployeeBusiness.GetStates();
            return View(ObjEmployee);
        }

        [HttpPost]
        public ActionResult Add(Employee objEmployee)
        {
            EmployeeRepository objEmployeeRepository = new EmployeeRepository();

            objEmployeeRepository.AddNewEmployee(objEmployee);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForCasCading(int? StateId, int? DistrictId)
        {
            string IsStateOrCity = "";
            Employee ObjEmployee = new Employee();

            ObjEmployee.States = objEmployeeBusiness.GetStates();

            if (StateId.HasValue)
            {
                IsStateOrCity = "state";
                ObjEmployee.Districts = objEmployeeBusiness.GetDistricts(StateId);
            }
            if (DistrictId.HasValue)
            {
                IsStateOrCity = "city";
                ObjEmployee.Cities = objEmployeeBusiness.GetCities(DistrictId);
            }


            if (IsStateOrCity == "state")
            {
                return Json(ObjEmployee.Districts, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(ObjEmployee.Cities, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int id)
        {
            Employee objEmployee = new Employee();
            bool IsUserExits;
            IsUserExits = objEmployeeBusiness.IsUserExits(id);

            if (IsUserExits)
            {
                objEmployee = objEmployeeBusiness.GetEmployeeDetails(id);
                return View("Add",objEmployee);
            }
            else
            {
                return View("User doest Exits");
            }

        }
        [HttpPost]
        public ActionResult Edit(Employee objEmployee)
        {
            new EmployeeRepository().UpdateEmployeeDetails(objEmployee);
            return RedirectToAction("Index","Home");
        }
    }
}