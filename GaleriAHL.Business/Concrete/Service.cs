using GaleriAHL.Business.Abstract;
using GaleriAHL.DataAccess;
using GaleriAHL.DataAccess.Concrete;
using GaleriAHL.Entities;

namespace GaleriAHL.Business.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext context) : base(context)//Service Constructor edildi. Repository içerisinde DataBaseContext'i constructor da parametre geçtiğimiz için DatabaseContext'i ister.
        {// Servis kullanılarak WEB UI'da servis üzerinden veritabanı işlemleri gerçekleştirilebilir.

        }
    }
}
