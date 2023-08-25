using System.Linq.Expressions;

namespace GaleriAHL.DataAccess.Abstract
{
    public interface IRepository<T> where T : class//<T> generic(tüm veritabanı classları için) çalışabilmesi için 
    {
        List<T> GetAll();//tüm kayıtlar
        List<T> GetAll(Expression<Func<T, bool>>expressions); //Parametre alan filtreye göre kayıtlar 
        T Get(Expression<Func<T, bool>> expressions);//kayıt getiren method
        T Find(int id);//dışarıdan bir id alır ve bu id ile eşleşen kaydı getirir.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Save(); //veritabanına değişiklilerin işleneceği metot imzası

        //Asenkron Metotlar(Async eklenmesi zorunlu) (.NET CORE'da hızlı şekilde işlem yapmamızı sağlar)
        //Entity Framework Core'da kullanabileceğimiz metotların karşılığı, Entity Framework Core'un daha özelleştirilmiş bir ypaısı olarak düşünülebilir 
        Task<T> FindAsync(int id);//parametre olarak dışarıdan int id alındı ve bu id ile eşleşen kaydı 
        Task<T> GetAsync(Expression<Func<T, bool>> expressions);
        Task<List<T>> GetAllAsync();//tüm kayıtlar
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expressions); //Parametre alan filtreye göre kayıtlar
        Task AddAsync(T entity);//asenkron bir şekilde hızlıca veritabanına kayıt etmemizi sağlar
        Task<int> SaveAsync();

    }
}
