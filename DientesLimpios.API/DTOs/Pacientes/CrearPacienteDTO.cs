using System.ComponentModel.DataAnnotations;

namespace DientesLimpios.API.DTOs.Pacientes;

public class CrearPacienteDTO
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
    public required string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El email no es válido.")]
    public required string Email { get; set; } = string.Empty;

}
