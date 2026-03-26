using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Persistencia.Repositorios;

public class RepositorioPacientes : Repositorio<Paciente>, IRepositorioPacientes
{
    public RepositorioPacientes(DientesLimpiosDbContext context) : base(context)
    {
    }

}
