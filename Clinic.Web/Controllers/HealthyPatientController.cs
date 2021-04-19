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
    }
}