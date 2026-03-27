using DientesLimpios.Dominio.Comunes;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DientesLimpios.Dominio.Entidades;

public class Paciente : EntidadAuditable
{

    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = null!;
    public Email Email { get; private set; } = null!;

    public Paciente(string nombre, string email)
    {
        AplicarReglasDeNegocioNombre(nombre);
        AplicarReglasDeNegocioEmail(email);

        Id = Guid.CreateVersion7();
        Nombre = nombre;
        Email = new Email(email);

    }

    //Constructor necesario para Entity Framework
    private Paciente()
    {
    }


    //Metodo para actualizar el Nombre del paciente
    public void ActualizarNombre(string nuevoNombre)
    {
        AplicarReglasDeNegocioNombre(nuevoNombre);
        Nombre = nuevoNombre;
    }
    public void ActualizarEmail(string nuevoEmail)
    {
        AplicarReglasDeNegocioEmail(nuevoEmail);
        Email = new Email(nuevoEmail);
    }







    private void AplicarReglasDeNegocioNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(nombre)} del paciente no puede estar vacío.");
        }
    }

    private void AplicarReglasDeNegocioEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(email)} del paciente no puede estar vacío.");
        }
    }


}
