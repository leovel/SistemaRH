using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel.Repository
{
    internal interface IRepository<T, K> where T : class where K : struct, IComparable, IComparable<K>
    {
        void Save(T entity);
        void SaveAll(IEnumerable<T> entities);
        T Find(K key);
        List<T> FindAll(Func<T, bool> filter = null);
        List<T> FindAllByKey(IEnumerable<K> keys);
    }
}
