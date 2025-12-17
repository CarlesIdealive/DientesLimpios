using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.Entidades;

public class Dentista
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    public Dentista(string nombre, string email)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(nombre)} del consultorio no puede estar vacío.");
        }
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(email)} del consultorio no puede estar vacío.");
        }
        if (!email.Contains("@"))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(email)} del consultorio no es válido.");
        }
        Id = Guid.CreateVersion7();
        Nombre = nombre;
        Email = email;
    }
}