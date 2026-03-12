using System.ComponentModel.DataAnnotations;

namespace EstudiantesAPI.DTOs
{
    public class EstudianteDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [MaxLength(150, ErrorMessage = "El correo no puede superar los 150 caracteres.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La carrera es obligatoria.")]
        [MaxLength(100, ErrorMessage = "La carrera no puede superar los 100 caracteres.")]
        public string Carrera { get; set; } = string.Empty;

        [Required(ErrorMessage = "La nota es obligatoria.")]
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10.")]
        public decimal Nota { get; set; }

        public bool Activo { get; set; } = true;
    }
}