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

        public ActionResult Add(int? StateId, int? DistrictId)
        {
            EmployeeBusiness objEmployeeBusiness = new EmployeeBusiness();

            Employee ObjEmployee = new Employee();

            ObjEmployee.CommunicationAddress.States = objEmployeeBusiness.GetStates();
            ObjEmployee.PermanentAddress.States = objEmployeeBusiness.GetStates();
            return View(ObjEmployee);
        }

        [HttpPost]
        public ActionResult Add(Employee objEmployee, bool IsPermanent)
        {
            EmployeeRepository objEmployeeRepository = new EmployeeRepository();

            objEmployeeRepository.AddNewEmployee(objEmployee,IsPermanent);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForCasCading(int? ComStateId, int? ComDistrictId, int? PerStateId, int? PerDistrictId)
        {
            EmployeeBusiness objEmployeeBusiness = new EmployeeBusiness();

            string IsComStateOrCity = "";
            string IsPerStateOrCity = "";
            Employee ObjEmployee = new Employee();

            ObjEmployee.CommunicationAddress.States = objEmployeeBusiness.GetStates();
            ObjEmployee.PermanentAddress.States = objEmployeeBusiness.GetStates();

            if (ComStateId.HasValue)
            {
                IsComStateOrCity = "state";
                ObjEmployee.CommunicationAddress.Districts = objEmployeeBusiness.GetDistricts(ComStateId);
            }
            if (ComDistrictId.HasValue)
            {
                IsComStateOrCity = "city";
                ObjEmployee.CommunicationAddress.Cities = objEmployeeBusiness.GetCities(ComDistrictId);
            }


            if (IsComStateOrCity == "state")
            {
                return Json(ObjEmployee.CommunicationAddress.Districts, JsonRequestBehavior.AllowGet);
            }
            if(IsComStateOrCity=="city")
            {
                return Json(ObjEmployee.CommunicationAddress.Cities, JsonRequestBehavior.AllowGet);
            }

            if (PerStateId.HasValue)
            {
                IsPerStateOrCity = "state";
                ObjEmployee.PermanentAddress.Districts = objEmployeeBusiness.GetDistricts(PerStateId);
            }
            if (PerDistrictId.HasValue)
            {
                IsPerStateOrCity = "city";
                ObjEmployee.PermanentAddress.Cities = objEmployeeBusiness.GetCities(PerDistrictId);
            }


            if (IsPerStateOrCity == "state")
            {
                return Json(ObjEmployee.PermanentAddress.Districts, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(ObjEmployee.PermanentAddress.Cities, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Edit(int id)
        {
            EmployeeBusiness objEmployeeBusiness = new EmployeeBusiness();

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