using GaleriAHL.DataAccess.Abstract;
using GaleriAHL.Entities;

namespace GaleriAHL.Business.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new() //IService DataAccess katmanında IRepository'i yönetir.
    {

    }
}
