namespace GaleriAHL.Entities
{
    public interface IEntity
    {
        public int Id { get; set; } //classlarda id zorunlu olacak ve veritabanı nesnelerini IEntity olarak işaretlemiş olucaz ve veritabanı harici hiç bir crud işlemlerinde kullanılamayacak !
    }
}
