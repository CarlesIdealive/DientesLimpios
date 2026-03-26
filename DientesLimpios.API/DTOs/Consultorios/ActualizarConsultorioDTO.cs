using System.ComponentModel.DataAnnotations;

namespace DientesLimpios.API.DTOs.Consultorios;

public class ActualizarConsultorioDTO
{
    [Required(ErrorMessage = "El campo 'Nombre' es obligatorio.")]
    [StringLength(100, ErrorMessage = "El campo 'Nombre' no puede exceder los 100 caracteres.")]
    public required string Nombre { get; set; }


}
