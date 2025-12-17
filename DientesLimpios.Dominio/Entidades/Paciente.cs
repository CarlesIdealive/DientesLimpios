namespace DientesLimpios.Dominio.Entidades;

public class Paciente
{

    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = null!;
    public string Email { get; private set; } = null!;


}
