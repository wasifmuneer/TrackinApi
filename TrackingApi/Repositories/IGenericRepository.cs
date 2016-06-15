using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApi.Repositories
{
    public interface IGenericRepository<T> where T :class
    {

        IEnumerable<T> Find();

        void Insert(T model);

        bool Delete(T model);

        bool Updatecontact(T model);

        T Get(string id);
    }
}
