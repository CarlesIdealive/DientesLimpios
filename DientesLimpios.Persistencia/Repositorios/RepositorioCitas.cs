using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Persistencia.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios;


public class RepositorioCitas : Repositorio<Cita>, IRepositorioCitas
{

    private readonly DientesLimpiosDbContext context;
    public RepositorioCitas(DientesLimpiosDbContext context)
        :base(context)
    {
        this.context = context;
    }

    public async Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin)
    {
        return await context.Citas
            .Where(c => c.DentistaId == dentistaId && c.EstadoCita == Dominio.Enums.EstadoCita.Programada
            && inicio < c.IntervaloDeTiempo.Inicio && fin > c.IntervaloDeTiempo.Inicio)
            .AnyAsync();

    }

    public async Task<IEnumerable<Cita>> ObtenerFiltrado(FiltroCitasDTO filtro)
    {
        var queryable = context.Citas
            .Include(c => c.Paciente)
            .Include(c => c.Dentista)
            .Include(c => c.Consultorio)
            .AsQueryable();

        if (filtro.ConsultorioId is not null)
            queryable = queryable.Where(p => p.ConsultorioId == filtro.ConsultorioId);
        if (filtro.PacienteId is not null)
            queryable = queryable.Where(p => p.PacienteId == filtro.PacienteId);
        if (filtro.DentistaId is not null)
            queryable = queryable.Where(p => p.DentistaId == filtro.DentistaId);
        queryable = queryable.Where(p => 
            p.IntervaloDeTiempo.Inicio >= filtro.FechaInicio && p.IntervaloDeTiempo.Fin <= filtro.FechaFin);

        //var totalPacientes = await ObtenerCantidadTotalRegistros();
        var dentistas = await queryable
            .OrderBy(p => p.IntervaloDeTiempo.Inicio)
            .Paginar(filtro.Pagina, filtro.RegistrosPorPagina)
            .ToListAsync();

        return dentistas;

    }




    new public async Task<Cita?> ObtenerPorId(Guid Id)
    {
        return await context.Citas
            .Include(c => c.Paciente)
            .Include(c => c.Dentista)
            .Include(c => c.Consultorio)
            .FirstOrDefaultAsync(c => c.Id == Id);
    }



}
