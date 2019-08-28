using BAProject.Model.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BAProject.DAL.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T: class //veya direk baseentity olabilir.
    {
        //IQueryable yerine enumerable kullanabilirsiniz. Queryable çok önerilmez ancak XML veya Json gibi dönüşler istiyorsak, performans için queryable olarak alabiliriz. Not: SOLID prensiplerine uygunluk açısından Enumerable daha doğrudur. Her davranışı çağırışımızda tekrar tanımlamak, kod tekrarı anlamına gelecektir. LINQ-TO-SQL veya LINQ-TO-OBJECT tercihinize bağlıdır. Queryable bize ifade ağacı(expression tree) döner ve çok daha performanslıdır(Enumerable tüm datayı cacheler, ifade ağacı ise ORM tarafından direk sqle çevrilebilir halde çok daha küçük bir boyutta saklanır.). Ancak tüm projemiz içerisinde toList() ile çalışacaksak, sadece SOLID'e ters düşen bir yapı kurmuş ve ekstra bir performans alamamış olacağımızı hatırlatayım.
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
