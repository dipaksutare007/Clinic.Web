using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic.Core;
using Clinic.EF.Entity;
namespace Clinic.Web.Controllers
{
    public class HealthyPatientController : Controller
    {

        private readonly Repository<Patient> _PatientRepository = null;
        private readonly Repository<City> _CityRepository = null;


        public HealthyPatientController()
        {
            _PatientRepository = new Repository<Patient>();
            _CityRepository = new Repository<City>();
        }
        // GET: HealthyPatient
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.CityId = new SelectList(_CityRepository.Getdata(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Patient objpatient)
        {
            ViewBag.CityId = new SelectList(_CityRepository.Getdata(), "Id", "Name");

            if(ModelState.IsValid)
            {
                _PatientRepository.Insert(objpatient);
                _PatientRepository.Save();
            }
            if(ModelState.IsValid==false)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return RedirectToAction("Add");
        }
    }
}