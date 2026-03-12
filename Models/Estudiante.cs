using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiantesAPI.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Carrera { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Nota { get; set; }

        public bool Activo { get; set; } = true;
    }
}
