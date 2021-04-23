using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinic.Core;
using Clinic.EF.Entity;
using Clinic.EF.ViewModel;
using Clinic.EF;
using System.Data.Entity;
namespace Clinic.Web.Controllers
{
    public class HealthyPatientController : Controller
    {

        private readonly Repository<Patient> _PatientRepository = null;
        private readonly Repository<City> _CityRepository = null;
        private ClinicDAL db = new ClinicDAL();

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
        public ActionResult Add(PatientViewModel objpatient)
        {
            ViewBag.CityId = new SelectList(_CityRepository.Getdata(), "Id", "Name");
            var Patients = new Patient { 
              //  Id=objpatient.Id,
                Name = objpatient.Name,
                Token = objpatient.Token,
                Sex = objpatient.Sex,
                BirthDate = objpatient.BirthDate,
                Phone = objpatient.Phone,
                Address = objpatient.Address,
                CityId = objpatient.CityId,
                DateTime = objpatient.DateTime,
                Height = objpatient.Height,
                Weight=objpatient.Weight

            };
            if(ModelState.IsValid)
            {
                if(objpatient.Id > 0)
                {
                    _PatientRepository.Update(Patients);
                    _PatientRepository.Save();
                }
                else 
                { 
                _PatientRepository.Insert(Patients);
                _PatientRepository.Save();
                }
            }
            if(ModelState.IsValid==false)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return RedirectToAction("Add");
        }

        public ActionResult List()
        {
           
            var patients = db.Patients.Include(p => p.Cities);
            return View(patients);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CityId = new SelectList(_CityRepository.Getdata(), "Id", "Name");
            var objpatient = _PatientRepository.GetbyID(id);
            var Patients = new PatientViewModel
            {
                Id = objpatient.Id,
                Name = objpatient.Name,
                Token = objpatient.Token,
                Sex = objpatient.Sex,
                BirthDate = objpatient.BirthDate,
                Phone = objpatient.Phone,
                Address = objpatient.Address,
                CityId = objpatient.CityId,
                DateTime = objpatient.DateTime,
                Height = objpatient.Height,
                Weight = objpatient.Weight

            };
            return View("Add", Patients);
        }

        public ActionResult Delete(int id)
        {
            var objpatient = _PatientRepository.GetbyID(id);
            _PatientRepository.Delete(objpatient);
            _PatientRepository.Save();
            return RedirectToAction("List");
        }



    }
}