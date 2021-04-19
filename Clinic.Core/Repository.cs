using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.ICore;
using Clinic.EF;
using System.Data.Entity;

namespace Clinic.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ClinicDAL db=null;
        private IDbSet<T> dbentity=null;

        public Repository()
        {
            db = new ClinicDAL();
            dbentity = db.Set<T>();
        }
        public Repository(ClinicDAL _db)
        {
            db = _db;
            dbentity = db.Set<T>();
        }
        public void Delete(T obj)
        {
            dbentity.Remove(obj);
        }

        public T GetbyID(object id)
        {
            return dbentity.Find(id);
        }

        public IEnumerable<T> Getdata()
        {
            return dbentity.ToList();
        }

        public void Insert(T obj)
        {
            dbentity.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
