using System.ComponentModel.DataAnnotations;

namespace GaleriAHL.Entities
{
    public class Musteri:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Araç"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public int AracId { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz !")]

        [StringLength(50)]
        public string Soyad { get; set; }
        [StringLength(11), Display(Name = "TC Kimlik No ")]
        public string? TcNo { get; set; }
        [StringLength(60),Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        
        public string Email { get; set; }
        [StringLength(500)]
        public string? Adres { get; set; }
        [StringLength(15)]
        public string? Telefon { get; set; }
        public string? Notlar { get; set; }
        [Display(Name = "Araç")]
        public virtual Arac? Arac { get; set; }

    }
}
