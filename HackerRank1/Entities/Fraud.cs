using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryService.WebAPI.Entities
{
    public class Fraud
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Los detalles del impostor son obligatorios.")]
        [StringLength(500, ErrorMessage = "Los detalles del impostor no pueden exceder 500 caracteres.")]
        public string ImpostorDetails { get; set; } = string.Empty;

        [Required(ErrorMessage = "La información de contacto es obligatoria.")]
        [StringLength(200, ErrorMessage = "La información de contacto no puede exceder 200 caracteres.")]
        public string ContactInfo { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Los comentarios no pueden exceder 1000 caracteres.")]
        public string Comments { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
