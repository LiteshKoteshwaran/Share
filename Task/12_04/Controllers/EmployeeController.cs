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
        //public ActionResult Add()
        //{
        //    ViewBag.States = objEmployeeBusiness.GetStates();
        //    return View(new tblEmployeeDetail());
        //}

        public ActionResult Add(int? StateId, int? DistrictId)
        {
            return View("Test", ObjEmployee);
        }

        public ActionResult ForCasCading(int? StateId, int? DistrictId)
        {
            Employee ObjEmployee = new Employee();

            ObjEmployee.States = objEmployeeBusiness.GetStates();

            if (StateId.HasValue)
            {
                ObjEmployee.Districts = objEmployeeBusiness.GetDistricts(StateId);

                if (DistrictId.HasValue)
                {
                    ObjEmployee.Cities = objEmployeeBusiness.GetCities(DistrictId);
                }
            }

            return Json(ObjEmployee, JsonRequestBehavior.AllowGet);
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

        //public List<tblMasDistrict> CascadeDistrict(int id)
        //{
        //    ViewBag.Districts = Json(objEmployeeBusiness.GetDistricts(id));
        //    return objEmployeeBusiness.GetDistricts(id);
        //}

        //public JsonResult CascadeDistrict(int id)
        //{
        //    return Json(objEmployeeBusiness.GetDistricts(id), JsonRequestBehavior.AllowGet);
        //    //return Json();
        //}

    }
}