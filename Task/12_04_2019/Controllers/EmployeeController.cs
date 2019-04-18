using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using _12_04_2019.Business;
using _12_04_2019.ControllerLogic;
using _12_04_2019.Entities;
using _12_04_2019.Models;

namespace _12_04_2019.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        EmployeeBusiness objEmployeeBusiness = new EmployeeBusiness();


        public ActionResult Add(int? StateId, int? DistrictId)
        {
            Employee ObjEmployee = new Employee();

            ObjEmployee.States = objEmployeeBusiness.GetStates();
            return View( ObjEmployee);
        }

        public ActionResult ForCasCading(int? StateId, int? DistrictId)
        {
            string IsStateOrCity="";
            Employee ObjEmployee = new Employee();

            ObjEmployee.States = objEmployeeBusiness.GetStates();

            if (StateId.HasValue)
            {
                IsStateOrCity = "state";
                ObjEmployee.Districts = objEmployeeBusiness.GetDistricts(StateId);

                if (DistrictId.HasValue)
                {
                    IsStateOrCity = "city";
                    ObjEmployee.Cities = objEmployeeBusiness.GetCities(DistrictId);
                }
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



        [HttpPost]
        public ActionResult Add(tblEmployeeDetail objEmployeeDetail)
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(tblEmployeeDetail objEmployeeDetail)
        {
            return View();
        }
    }
}