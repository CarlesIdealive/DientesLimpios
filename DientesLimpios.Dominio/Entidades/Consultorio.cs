using DientesLimpios.Dominio.Comunes;
using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.Entidades;

public class Consultorio : EntidadAuditable
{

    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = null!; //El set es PRIVADO porque el nombre solo se puede establecer a través del constructor o del método ActualizarNombre, lo que permite aplicar las reglas de negocio correspondientes.


    public Consultorio(string nombre)
    {
        AplicarReglasDeNegocioNombre(nombre);
        Nombre = nombre;
        Id = Guid.CreateVersion7();
    }

    //Metodo para actualizar el Nombre del consultorio
    public void ActualizarNombre(string nuevoNombre)
    {
        AplicarReglasDeNegocioNombre(nuevoNombre);
        Nombre = nuevoNombre;
    }


    private void AplicarReglasDeNegocioNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(nombre)} del consultorio no puede estar vacío.");
        }
    }


}
