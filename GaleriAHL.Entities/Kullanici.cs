using System.ComponentModel.DataAnnotations;

namespace GaleriAHL.Entities
{
    public class Kullanici : IEntity //YAPILAN HER ŞEY DataAnnotations kütüphanesinden gelir !
    {
        public int Id { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz !")] 
        //Update'de de gelmesin sistemden gelsin diye kullanıldı!
        public string Ad { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]//Update'de de gelmesin sistemden gelsin diye kullanıldı!
        public string Soyad { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Email { get; set; }
        [StringLength(20)]
        public string? Telefon { get; set; }
        [StringLength(50)]
        public string? KullaniciAdi { get; set; }
        [StringLength(50), Display(Name ="Şifre"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        [Display(Name ="Eklenme Tarihi"), ScaffoldColumn(false)]//Update'de de gelmesin sistemden gelsin diye kullanıldı! ScaffoldColumn(false) = ekranda property için gerekli alanları oluşturmaz.
        public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;//elle girmemek adına ? nullable olarak işaretledim ve şimdiki zamanı alsın dedim
        [Display(Name = "Kullanıcı Rolü"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public int RolId { get; set; }
        [Display(Name = "Kullanıcı Rolü")]
        public virtual Rol? Rol { get; set;} //userları elle girmemek adına nullable yaptım yani default olarak user rolü gelir
    }
}
