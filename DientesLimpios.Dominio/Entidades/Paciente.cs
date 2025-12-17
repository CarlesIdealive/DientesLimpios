using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.Entidades;

public class Paciente
{

    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    public Paciente(string nombre, string email)
    {
        
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(nombre)} del paciente no puede estar vacío.");
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(email)} del paciente no puede estar vacío.");
        }
        if (!email.Contains("@"))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(email)} del paciente no es válido.");
        }

        Id = Guid.CreateVersion7();
        Nombre = nombre;
        Email = email;
    }

}
