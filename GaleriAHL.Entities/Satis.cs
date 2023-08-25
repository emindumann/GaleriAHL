using System.ComponentModel.DataAnnotations;

namespace GaleriAHL.Entities
{
    public class Satis : IEntity 
    {
        public int Id { get; set; }
        [Display(Name = "Araç "), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public int AracId { get; set; }
        [Display(Name = "Müşteri "), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public int MusteriId { get; set; }
        [Display(Name = "Satış Fiyatı "), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public decimal SatisFiyat { get; set; }
        [Display(Name = "Satış Tarihi "), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public DateTime SatisTarih { get; set; }
        [Display(Name = "Araç")]
        public virtual Arac? Arac { get; set; }
        [Display(Name = "Müşteri")]
        public virtual Musteri? Musteri { get; set; }


    }
}
