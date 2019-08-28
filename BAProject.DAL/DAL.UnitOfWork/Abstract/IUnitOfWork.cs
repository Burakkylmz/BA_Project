using BAProject.DAL.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAProject.DAL.DAL.UnitOfWork.Abstract
{
    public interface IUnitOfWork:IDisposable //Disposable mecburi değildir. Bellekte yer oldukça garbage collector silmemeye çalışacaktır. İşlem sonunda nesnenin serbest bırakılması için eklendi. Dispose metodu bu arayüzden yararlanacak sınıflarda implemente edilmelidir.
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges(); //Değişiklikler test sürecinde yardımcı olması için repoya eklenmedi. İstenirse unitOfWork yerine bu metot oraya çekilebilir. Ancak Repo içerisindeki add update gibi metotlarda save çağırılmaması Single Responsibility için daha uygundur. Yeni bir metot açılabilir.
    }
}