using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_04_2019.ControllerLogic;
using _12_04_2019.Models;

namespace _12_04_2019.Business
{
    public class EmployeeBusiness
    {
        EmployeeRepository ObjEmployeeRepository = new EmployeeRepository();
        public List<SelectListItem> GetStates()
        {
            return ObjEmployeeRepository.FetchStates();
        }

        public List<SelectListItem> GetDistricts(int? Id)
        {
            List<SelectListItem> Districts = new List<SelectListItem>();
            var districts = ObjEmployeeRepository.FetchDistricts(Id);

            foreach (var district in districts)
            {
                Districts.Add(new SelectListItem { Text = district.DistrictName, Value = district.DistrictID.ToString() });
            }

            return Districts;
        }
        
        public List<SelectListItem> GetCities(int? Id)
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            var cities = ObjEmployeeRepository.FetchCities(Id);

            foreach (var city in cities)
            {
                Cities.Add(new SelectListItem { Text = city.DistrictName, Value = city.DistrictID.ToString() });
            }

            return Cities;
        }
    }
}