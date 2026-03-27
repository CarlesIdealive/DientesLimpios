using DientesLimpios.Aplicacion.CasosDeUso.Dentista.Consultas;

namespace DientesLimpios.Aplicacion.Contratos.Repositorios;

public interface IRepositorioDentistas : IRepositorio<DientesLimpios.Dominio.Entidades.Dentista>
{
    Task<IEnumerable<DientesLimpios.Dominio.Entidades.Dentista>> ObtenerFiltrado(FiltroDentistaDTO filtro);
}
