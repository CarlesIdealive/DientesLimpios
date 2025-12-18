using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;

public class CasoDeUsoCrearConsultorio
{
    private readonly IRepositorioConsultorios _repositorio;
    public CasoDeUsoCrearConsultorio(IRepositorioConsultorios repositorio)
    {
        _repositorio = repositorio;
    }



    public async Task<Guid> Handle(ComandoCrearConsultorio comando)
    {
        // Lógica para crear un consultorio - Orquestación del dominio
        // Por ejemplo, validar datos, guardar en base de datos, etc.
        // Simulación de creación y retorno de un ID único para el consultorio creado
        var consultorio = new Consultorio(comando.Nombre);
        var respuesta = await _repositorio.Agregar(consultorio);
        return respuesta.Id;

    }
}
