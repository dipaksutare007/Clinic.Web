using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.ICore
{
    public interface IRepository<T> where T:class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> Getdata();
        T GetbyID(object id);
        void Save();

    }
}
