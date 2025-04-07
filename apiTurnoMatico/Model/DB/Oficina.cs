using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiTurnoMatico.Model.DB
{
    [Table("Oficina")]
    public class Oficina
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre {  get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        [Required]
        public int Aforo { get; set; }
        [Required]
        public int CajasDisponibles { get; set; }
        public bool esMoto { get; set; }
        public int? status { get; set; }
    }
}
