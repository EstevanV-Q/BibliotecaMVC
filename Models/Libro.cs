using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaMVC.Models
{
    public class Libro
    {
        [Required(ErrorMessage = "El código es obligatorio.")]
        [StringLength(10, ErrorMessage = "El código no puede exceder los 10 caracteres.")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Publicación")]
        public DateTime FechaPublicacion { get; set; }
    }
}
