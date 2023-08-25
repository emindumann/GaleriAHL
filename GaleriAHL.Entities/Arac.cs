using System.ComponentModel.DataAnnotations;

namespace GaleriAHL.Entities
{
    public class Arac : IEntity //Car, IEntity'den referans alır
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public int MarkaId { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]//DataAnnotation uzunluk belirtir.
        public string Renk { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public decimal Fiyat { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Model { get; set; }
        [StringLength(50), Display(Name = "Kasa Tipi "), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string KasaTip { get; set; }
        [Display(Name = "Model Yılı ")]
        public int ModelYil { get; set; }
        [Display(Name = "Satışta mı ? ")]
        public bool SatistaMi { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Not { get; set; }
        [StringLength(100)]
        public string? Resim1 { get; set; }
        [StringLength(100)]
        public string? Resim2 { get; set; }
        [StringLength(100)]
        public string? Resim3 { get; set; }
        public virtual Marka? Marka { get; set; } //Araç sınıfı ile Marka sınıfı arasında bağlantı kuruldu.
    }
}
