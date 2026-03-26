using System.ComponentModel.DataAnnotations;

namespace DientesLimpios.API.DTOs.Consultorios;

public class CrearConsultorioDTO
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public required string Nombre { get; set; } = string.Empty;

}
