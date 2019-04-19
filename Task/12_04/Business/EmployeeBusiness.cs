using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _12_04.ControllerLogic;
using _12_04.Models;

namespace _12_04.Business
{
    public class EmployeeBusiness
    {
        EmployeeRepository ObjEmployeeRepository = new EmployeeRepository();
        public List<State> GetStates()
        {
            return ObjEmployeeRepository.FetchStates();
        }

        public List<District> GetDistricts(int? Id)
        {
            return ObjEmployeeRepository.FetchDistricts(Id);
        }

        public List<City> GetCities(int? Id)
        {
            return ObjEmployeeRepository.FetchCities(Id);
        }

        public bool IsUserExits(int id)
        {
            return ObjEmployeeRepository.CheckForEmployee(id);
        }

        public Employee GetEmployeeDetails(int EmployeeID)
        {
            Employee employee = new Employee();
            employee = ObjEmployeeRepository.FetchEmployeeDetails(EmployeeID);
            return employee;
        }
    }
}