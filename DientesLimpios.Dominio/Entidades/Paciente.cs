using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Dominio.Entidades;

public class Paciente
{

    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = null!;
    public Email Email { get; private set; } = null!;

    public Paciente(string nombre, string email)
    {
        
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(nombre)} del paciente no puede estar vacío.");
        }

        Id = Guid.CreateVersion7();
        Nombre = nombre;
        Email = new Email(email);
    }

}
