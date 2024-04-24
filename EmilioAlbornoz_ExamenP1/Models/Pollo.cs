

using System.ComponentModel.DataAnnotations;

namespace EmilioAlbornozBurger.Models
{
    public class Pollo
    {
        [Key]
        public int EA_PolloId { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(10, ErrorMessage = "El nombre no puede exceder los 10 letras")]
        public string? EA_Nombre { get; set; }

        [Range(1, 5, ErrorMessage = "El numero de piezas debe estar entre 1 y 5")]
        public int EA_Piezas { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Elaboracion")]
        public DateTime EA_FechadeProduccion { get; set; }

        [Range(0.01, 9999.99, ErrorMessage = "El precio debe estar entre 0.01 - 9999")]
        public decimal EA_Price { get; set; }

        [Display(Name = "Incluye Salsa")]
        public bool EA_IncluyeSalsa { get; set; }

    }
}
