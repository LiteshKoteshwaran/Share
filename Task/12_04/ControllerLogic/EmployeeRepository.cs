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

        public List<SelectListItem> FetchStates()
        {
            List<SelectListItem> States = new List<SelectListItem>();
            foreach (var State in entities.tblMasStates)
            {
                States.Add(new SelectListItem { Text = State.StateName, Value = State.StateID.ToString() });
            }
            return States;
        }
        public dynamic FetchDistricts(int? Id)
        {
            var districts = (from district in entities.tblMasDistricts
                             where district.DistrictStateID == Id.Value
                             select district).ToList();
            return districts;
        }
        
        public dynamic FetchCities(int? Id)
        {
            var cities = (from Cities in entities.tblMasCities
                where Cities.CityDistrictID == Id.Value
                select Cities).ToList();
            return cities;
        }
    }
}
