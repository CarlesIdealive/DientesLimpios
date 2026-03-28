using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Persistencia.Repositorios;


public class RepositorioCitas : Repositorio<Cita>, IRepositorioCitas
{

    private readonly DientesLimpiosDbContext context;
    public RepositorioCitas(DientesLimpiosDbContext context)
        :base(context)
    {
        this.context = context;
    }



}
