using BAProject.DAL.DAL.Context;
using BAProject.DAL.DAL.Repositories.Abstract;
using BAProject.DAL.DAL.Repositories.Concrete;
using BAProject.DAL.DAL.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAProject.DAL.DAL.UnitOfWork.Concrete
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly BAProjeContext _dbContext;
        public EFUnitOfWork(BAProjeContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("Context bulunamadı!");

            _dbContext = dbContext;

            //Bu noktada lazy loading vb işlemler eklenebilir.
            //Eski kod:
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //Yeni Kod:
            //_dbContext.ChangeTracker.LazyLoadingEnabled = false;
        }

        //Garbage collector ve dispose kullanımı alttaki linkte açıklanmıştır.
        // https://stackoverflow.com/questions/151051/when-should-i-use-gc-suppressfinalize

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
           
            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                //Burada transaction vb implementasyonlar yapılabilir.
                return _dbContext.SaveChanges();
            }
            catch
            {
                //Burada hata yönetimi yapılabilir ancak bu kadar low level bir kod bloğunda birçok hata gözden kaçabilir.
                throw;
            }
        }
    }
}
