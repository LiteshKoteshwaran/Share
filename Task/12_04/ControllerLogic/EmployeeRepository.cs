using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _12_04.Models;
using _12_04.Entities;
using System.Web.Mvc;

namespace _12_04.ControllerLogic
{
    public class EmployeeRepository
    {
        TaskEntities entities = new TaskEntities();
        private bool IsSuccess = true;
        tblEmployeeDetail objTblEmployeeDetail = new tblEmployeeDetail();
        Employee objEmployee = new Employee();
        public List<State> FetchStates()
        {
            List<State> States = new List<State>();
            foreach (var State in entities.tblMasStates)
            {
                States.Add(new State {StateID = State.StateID, States = State.StateName});   
            }
            return States;
        }
        public List<District> FetchDistricts(int? Id)
        {
            List<tblMasDistrict> districts = entities.tblMasDistricts.ToList().FindAll(obj => obj.DistrictStateID == Id);
            List<District> Districts = new List<District>();
            foreach (var dis in districts)
            {
                Districts.Add(new District { DistrictID = dis.DistrictID, Districts = dis.DistrictName });
            }
            return Districts;
        }

        public List<City> FetchCities(int? Id)
        {
            List<tblMasCity> cities = entities.tblMasCities.ToList().FindAll(obj => obj.CityDistrictID == Id);
            List<City> Cities = new List<City>();
            foreach (var city in cities)
            {
                Cities.Add(new City {CityID = city.CityID, Cities = city.CityName});
            }
            return Cities;
        }

        public void UpdateEmployeeDetails(Employee employee)
        {
            objTblEmployeeDetail = entities.tblEmployeeDetails.ToList().Find(objTblEmployee => objTblEmployee.EmployeeDetailsID == employee.EmployeeID);
            UpdateEmployee(objTblEmployeeDetail,employee);
        }
        public void UpdateEmployee(tblEmployeeDetail objTblEmp ,Employee objEmployee)
        {
            objTblEmp.FirstName = objEmployee.FirstName;
            objTblEmp.LastName = objEmployee.LastName;
            objTblEmp.Email = objEmployee.Email;
            objTblEmp.Mobile = objEmployee.Mobile;
            objTblEmp.Phone = objEmployee.Phone;

            objTblEmp.tblAddress = ConvertAddress(objEmployee.CommunicationAddress);

            objTblEmp.tblAddress1 = ConvertAddress(objEmployee.PermanentAddress);

            entities.SaveChanges();
        }

        public bool AddNewEmployee(Employee objEmployee)
        {
            try
            {
                objTblEmployeeDetail.FirstName = objEmployee.FirstName;
                objTblEmployeeDetail.LastName = objEmployee.LastName;
                objTblEmployeeDetail.Email = objEmployee.Email;
                objTblEmployeeDetail.Mobile = objEmployee.Mobile;
                objTblEmployeeDetail.Phone = objEmployee.Phone;

                objTblEmployeeDetail.tblAddress = ConvertAddress(objEmployee.CommunicationAddress); ;

                objTblEmployeeDetail.tblAddress1 = ConvertAddress(objEmployee.PermanentAddress);

                entities.tblEmployeeDetails.Add(objTblEmployeeDetail);
                entities.SaveChanges();
            }
            catch (Exception e)
            {
                IsSuccess = false;
            }
            return IsSuccess;
        }

        public tblAddress ConvertAddress(Address objAddress)
        {
            tblAddress objTblAddress = new tblAddress();

            objTblAddress.Address1 = objAddress.Address1;
            objTblAddress.Address2 = objAddress.Address2;
            objTblAddress.Address3 = objAddress.Address3;
            objTblAddress.StateID = objAddress.State.StateID;
            objTblAddress.DistrictID = objAddress.District.DistrictID;
            objTblAddress.CityID = objAddress.City.CityID;
            objTblAddress.Pincode = objAddress.Pincode;

            return objTblAddress;

        }

        public bool CheckForEmployee(int EmployeeID)
        {
            return entities.tblEmployeeDetails.ToList().Any(objEmp => objEmp.EmployeeDetailsID == EmployeeID);
        }

        public Employee FetchEmployeeDetails(int EmployeeID)
        {
            objTblEmployeeDetail = entities.tblEmployeeDetails.ToList().Find(objTblEmployee => objTblEmployee.EmployeeDetailsID == EmployeeID);

            return objEmployee = ConvertTblEmployee(objTblEmployeeDetail);
        }

        public Employee ConvertTblEmployee(tblEmployeeDetail objTblEmployee)
        {
            objEmployee.EmployeeID = objTblEmployee.EmployeeDetailsID;
            objEmployee.FirstName = objTblEmployee.FirstName;
            objEmployee.LastName = objTblEmployee.LastName;
            objEmployee.Email = objTblEmployee.Email;
            objEmployee.Mobile = objTblEmployee.Mobile;
            objEmployee.Phone = objTblEmployee.Phone;

            objEmployee.CommunicationAddress = ConvertTblAddress(objTblEmployee.tblAddress);

            objEmployee.PermanentAddress = ConvertTblAddress(objTblEmployee.tblAddress1);

            return objEmployee;
        }

        public Address ConvertTblAddress(tblAddress objTblAddress)
        {
            Address objAddress = new Address();
            State state = new State();
            District district = new District();
            City city = new City();

            objAddress.Address1 = objTblAddress.Address1;
            objAddress.Address2 = objTblAddress.Address2;
            objAddress.Address3 = objTblAddress.Address3;

            
            state.StateID = objTblAddress.StateID;
            state.States = objTblAddress.tblMasState.StateName;

            district.DistrictID = objTblAddress.DistrictID;
            district.Districts = objTblAddress.tblMasDistrict.DistrictName;

            city.CityID = objTblAddress.CityID;
            city.Cities = objTblAddress.tblMasCity.CityName;

            objAddress.State = state;
            objAddress.District = district;
            objAddress.City = city;
            objAddress.Pincode = objTblAddress.Pincode;

            return objAddress;
        }
    }
}
