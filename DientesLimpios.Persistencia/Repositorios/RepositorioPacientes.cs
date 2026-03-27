using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Persistencia.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios;

public class RepositorioPacientes : Repositorio<Paciente>, IRepositorioPacientes
{
    private readonly DientesLimpiosDbContext context;

    public RepositorioPacientes(DientesLimpiosDbContext context) 
        : base(context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Paciente>> ObtenerFiltrado(FiltroPacienteDTO filtro)
    {

        var queryable = context.Pacientes.AsQueryable();

        if (!string.IsNullOrEmpty(filtro.Nombre))
        {
            queryable = queryable.Where(p => p.Nombre.Contains(filtro.Nombre));
        }
        if (!string.IsNullOrEmpty(filtro.Email))
        {
            queryable = queryable.Where(p => p.Email.Valor.Contains(filtro.Email));
        }

        //var totalPacientes = await ObtenerCantidadTotalRegistros();
        var pacientes = await queryable
            .OrderBy(p => p.Nombre)
            .Paginar(filtro.Pagina, filtro.RegistrosPorPagina)
            .ToListAsync();
        return pacientes;

    }
}
