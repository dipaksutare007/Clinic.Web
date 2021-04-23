using Clinic.EF.CustomValidation;
using Clinic.EF.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.EF.ViewModel
{
   public class PatientViewModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        [Required]
        public string Name { get; set; }
        public Gender Sex { get; set; }
        [DateMinimumAge(18, ErrorMessage = "{0} must be someone at least {1} years of age")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte CityId { get; set; }
        public City Cities { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        public int Age
        {
            get; set;
            //get
            //{
            //    var now = DateTime.Today;
            //    var age = now.Year - BirthDate.Year;
            //    if (BirthDate > now.AddYears(-age)) age--;
            //    return age;
            //}

        }

    }

}
