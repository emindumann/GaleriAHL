using System.ComponentModel.DataAnnotations;

namespace GaleriAHL.Entities
{
    public class Servis : IEntity//IEntity'den kalıtım alıyor.
    {
        public int Id { get; set; }
        //[Display(Name = "Servise Geliş Tarihi"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public DateTime ServisGelisTarih { get; set; }
        //[Display(Name = "Araç Sorunu"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string AracSorunu { get; set; }
        //[Display(Name = "Servis Ücreti"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public decimal ServisUcret { get; set; }
        //[Display(Name = "Servis Çıkış Tarihi"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public DateTime ServisCikisTarih { get; set; }
        //[Display(Name = "Yapılan İşlem")]
        public string? YapilanIslem { get; set; }
        //[Display(Name = "Garanti Kapsamında mı ?"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public bool GarantiKapsamindaMi { get; set; }
        //[StringLength(15), Display(Name ="Araç Plaka"), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string AracPlaka { get; set; }
        //[StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Marka { get; set; }
        //[StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Model { get; set; }
        //[StringLength(50),Display(Name = "Kasa Tipi")]

        public string? KasaTip { get; set; }
        //[StringLength(50), Display(Name = "Şase No")]
        public string? SaseNo { get; set; }
        //[Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Notlar { get; set; }

    }
}
