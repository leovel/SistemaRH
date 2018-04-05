using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.DataModel.Repository
{
    internal abstract class RepositoryBase<T, K> : IRepository<T, K> where T : class where K : struct, IComparable, IComparable<K>
    {
        public T Find(K key)
        {
            try
            {
                using (var context = new RHModelContainer())
                {
                    return Find(key, context);
                }
            }
            catch (Exception exc)
            {
                throw new Exception($"Erro na Funçao: {nameof(Find)} do Objeto: {this.ToString()}", exc);
            }
        }

        public virtual T Find(K key, RHModelContainer context)
        {
            return context.Set<T>().Find(key);
        }

        public List<T> FindAll(Func<T, bool> filter = null)
        {
            try
            {
                using (var context = new RHModelContainer())
                {
                    return FindAll(context, filter);
                }
            }
            catch (Exception exc)
            {

                throw new Exception($"Erro na Funçao: {nameof(FindAll)} do Objeto: {this.ToString()}", exc);
            }
        }

        public virtual List<T> FindAll(RHModelContainer context, Func<T, bool> filter = null)
        {
            var pquery = context.Set<T>().AsParallel();
            return filter == null ? pquery.ToList() : pquery.Where(o => filter(o)).ToList();
        }

        public List<T> FindAllByKey(IEnumerable<K> keys)
        {
            try
            {
                return keys.Select(k => Find(k)).ToList();
            }
            catch (Exception exc)
            {

                throw new Exception($"Erro na Funçao: {nameof(FindAllByKey)} do Objeto: {this.ToString()}", exc);
            }
        }

        public virtual void Save(T entity)
        {
            try
            {
                using (var context = new RHModelContainer())
                {
                    if (Save(entity, context))
                        context.SaveChanges();
                }
            }
            catch (Exception exc)
            {

                throw new Exception($"Erro na Funçao: {nameof(Save)} do Objeto: {this.ToString()}", exc);
            }
        }

        public abstract bool Save(T entity, RHModelContainer context);

        public void SaveAll(IEnumerable<T> entities)
        {
            Parallel.ForEach(entities, e => { Save(e); });
        }
    }
}
