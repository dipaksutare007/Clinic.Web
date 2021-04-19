using Clinic.EF.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.EF
{
    public class ClinicDAL : DbContext
    {
        public ClinicDAL():base("name=ClinicDAL")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>().ToTable("Patient");
        }

        public DbSet<Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<Clinic.EF.Entity.City> Cities { get; set; }
    }
}
