using System.ComponentModel.DataAnnotations;

namespace GaleriAHL.Entities
{
    public class Rol : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz !")]
        public string Ad { get; set; }
    }
}
