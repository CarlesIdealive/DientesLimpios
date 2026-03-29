using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Contratos.Repositorios;

public interface IRepositorioCitas : IRepositorio<Cita>
{
    Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin);
    new Task<Cita?> ObtenerPorId(Guid Id);
    Task<IEnumerable<Cita>> ObtenerFiltrado(FiltroCitasDTO filtro);

}
