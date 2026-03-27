using DientesLimpios.Aplicacion.CasosDeUso.Dentista.Consultas;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Persistencia.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios;

public class RepositorioDentistas : Repositorio<Dentista>, IRepositorioDentistas
{
    private readonly DientesLimpiosDbContext context;

    public RepositorioDentistas(DientesLimpiosDbContext context) 
        : base(context)
    {
        this.context = context;

    }

    public async Task<IEnumerable<Dentista>> ObtenerFiltrado(FiltroDentistaDTO filtro)
    {
        var queryable = context.Dentistas.AsQueryable();

        if (!string.IsNullOrEmpty(filtro.Nombre))
        {
            queryable = queryable.Where(p => p.Nombre.Contains(filtro.Nombre));
        }
        if (!string.IsNullOrEmpty(filtro.Email))
        {
            queryable = queryable.Where(p => p.Email.Valor.Contains(filtro.Email));
        }

        //var totalPacientes = await ObtenerCantidadTotalRegistros();
        var dentistas = await queryable
            .OrderBy(p => p.Nombre)
            .Paginar(filtro.Pagina, filtro.RegistrosPorPagina)
            .ToListAsync();

        return dentistas;

    }
}
