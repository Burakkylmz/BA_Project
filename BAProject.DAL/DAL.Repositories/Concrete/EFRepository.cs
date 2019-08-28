using BAProject.DAL.DAL.Context;
using BAProject.DAL.DAL.Repositories.Abstract;
using BAProject.Model.Model.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BAProject.DAL.DAL.Repositories.Concrete
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public EFRepository(BAProjeContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Context bulunamadı!");

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity.GetType().GetProperty("EntityStatus") != null)
            {
                T _entity = entity;

                _entity.GetType().GetProperty("EntityStatus").SetValue(_entity, Status.Active);
            }
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            //Reflection ile base status yakalıyoruz. Bunun nedeni BaseEntity'den bağımsız tasarlamamdı. İsteğe bağlıdır.
            if (entity.GetType().GetProperty("EntityStatus") != null)
            {
                T _entity = entity;

                _entity.GetType().GetProperty("EntityStatus").SetValue(_entity, Status.Passive);

                this.Update(_entity);
            }
            else
            {
                // Önce entity'nin state'ini kontrol etmeliyiz.
                EntityState dbEntityEntryState = _dbContext.Entry(entity).State;

                if (dbEntityEntryState != EntityState.Deleted)
                {
                    dbEntityEntryState = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            else
            {
                if (entity.GetType().GetProperty("EntityStatus") != null)
                {
                    T _entity = entity;
                    _entity.GetType().GetProperty("EntityStatus").SetValue(_entity, Status.Passive);

                    this.Update(_entity);
                }
                else
                {
                    Delete(entity);
                }
            }
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}