using GaleriAHL.DataAccess.Abstract;
using GaleriAHL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GaleriAHL.DataAccess.Concrete //repository pattern sayfası
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new() //Repository'deki T ifadesi clasları ifade eder.  Repository IRepository'den kalıtım alır. new() = gelecek olan şartlar newlenebilir olması gerekir. şartlar = T'nin bir class olması lazım ve Veritabanı Nesnesi olarak işaretlenmesi alzım(IEntity)
    {// IRepository<T> deki metotlar implemente edildi.
        internal DatabaseContext _context; //entity framework kullanılarak gelen classlara ekleme yapılır.
        internal DbSet<T> _dbSet;//DatabaseContext içerisindeki dbsetleri kullanabilmek için eklendi. ve DbSet <T> ifadesinden dolayı generictir yani araç marka falan dışarıdan gönderilir ve onun için çalışılır.
        public Repository(DatabaseContext context)
        {//yukarıda tanımlanan DatabaseContext context'inin içi boştur o yüzden generate constructor yaptık ve içini burada doldururuz
            _context = context;
            _dbSet = _context.Set<T>(); //gelen <T> için yukarıdaki context'e abone ol ve o T için işlemler yap
        }

        
        public void Add(T entity)
        {//veritabanına gelen T yani class eklenir.
            _dbSet.Add(entity); //gelen dbset'i ekle          yani veritabanı eklemek için işaretliyor, ekleme işlemi save metotundan sonra çalışıyor.
        }
        //throw new NotImplementedException(); = metotun yapacağı iş tanımlanmadı.
        public async Task AddAsync(T entity)//bu AddAsync ise bizim yazdığımız.
        {
            await _dbSet.AddAsync(entity); // yukarıdaki işlemin asenkron hali. buradaki AddAsync bizim yazdığımız değil ef core'un Add Async'i
        }

        public void Delete(T entity)
        {
            _dbSet?.Remove(entity); //entity'i silinmek üzere işaretle
        }

        public T Find(int id)
        {
            return _dbSet.Find(id); //geriye T döndürür. bize gelen id ile eşleşen kaydı geriye döndür.
        }

        public async Task<T> FindAsync(int id)
        {
            return await _dbSet.FindAsync(id); //asenkron işaretlemelerde fonksiyonun başına await koyulur. Dışarıdan id gelicek ve eşleşeni döndürücez yukarıdakinin asenkron hali.
        }

        public T Get(Expression<Func<T, bool>> expressions)
        {
            return _dbSet.FirstOrDefault(expressions);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList(); //tüm dataları listeler
        }

        public List<T> GetAll(Expression<Func<T, bool>> expressions)
        {
            return _dbSet.Where(expressions).ToList(); //lambda expression'a göre metotu uygula sonra listele ve geriye döndür.
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expressions)
        {
            return await _dbSet.Where(expressions).ToListAsync(); //geriye dönmeden önce expression koşulunu uygula sonra dön.
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> expressions)
        {
            return _dbSet.FirstOrDefaultAsync(expressions);
        }

        public int Save()//geriye int dönmesi etkilenen kayıt sayısı demek
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();// asenkron metotlarda await anahtar kelimesi koyulur.

        }

        public void Update(T entity)
        {
            _context.Update(entity);//gelen entity'i güncellenecek olarak işaretler
        }
    }
}
