using DientesLimpios.Aplicacion.Contratos.Persistencia;

namespace DientesLimpios.Persistencia.UnidadesDeTrabajo;

public class UnidadDeTrabajoEFCore : IUnidadDeTrabajo
{
    private readonly DientesLimpiosDbContext _context;

    public UnidadDeTrabajoEFCore(DientesLimpiosDbContext context)
    {
        _context = context;
    }

    public Task Persistir()
    {
        return _context.SaveChangesAsync();
    }

    public Task Reversar()
    {
        return Task.CompletedTask;

    }
}
