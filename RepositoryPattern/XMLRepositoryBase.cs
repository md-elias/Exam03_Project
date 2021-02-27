using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;
using Repository_Domain;
using Repository_Source;

namespace RepositoryPattern
{
    public class XMLRepositoryBase<TContext, TEntity, TKey> : IRepository<TEntity, TKey> where TContext : XMLSet<TEntity> where TEntity : class
    {
        private XMLSet<TEntity> m_context;

        public XMLRepositoryBase(string fileName)
        {
            m_context = new XMLSet<TEntity>(fileName); 
        }

        public bool Delete(TKey id)
        {
            try
            {
                List<IEntity<TKey>> items = m_context.Data as List<IEntity<TKey>>;
                items.Remove(items.First(f => f.OperatorID.Equals(id)));
                m_context.Data = items as ICollection<TEntity>; 
                return true;
            } 
            catch (Exception)
            { 
                return false; 
            } 
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try 
            { 
                var list = m_context.Data.AsQueryable().Where(predicate).ToList();
                return list as ICollection<TEntity>; 
            } catch (Exception)
            { 
                return null; 
            }
        }

        public TEntity Get(TKey id)
        {
            try
            {
                List<IEntity<TKey>> items = m_context.Data as List<IEntity<TKey>>;
                return items.FirstOrDefault(f => f.OperatorID.Equals(id)) as TEntity;
            }
            catch (Exception) { return null; }
        }

        public ICollection<TEntity> GetAll()
        { 
            return m_context.Data; 
        }

        public TKey Insert(TEntity model) 
        {
            var list = m_context.Data; list.Add(model);
            m_context.Data = list; return default(TKey); 
        }

        public bool Remove(TKey id) 
        {
            return Delete(id);
        }

        public bool Update(TEntity model)
        {
            try 
            { IEntity<TKey> imodel = model as IEntity<TKey>; 
                List<IEntity<TKey>> items = m_context.Data as List<IEntity<TKey>>; 
                items.Remove(items.FirstOrDefault(f => f.OperatorID.Equals(imodel.OperatorID)));
                items.Add(imodel); 
                m_context.Data = items as ICollection<TEntity>; 
                return true; 
            } 
            catch (Exception)
            { 
                return false; 
            } 
        }
    }
}