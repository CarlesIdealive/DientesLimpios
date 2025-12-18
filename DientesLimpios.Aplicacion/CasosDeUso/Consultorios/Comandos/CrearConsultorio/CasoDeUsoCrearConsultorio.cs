using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;

public class CasoDeUsoCrearConsultorio
{
    private readonly IRepositorioConsultorios _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;
    private readonly IValidator<ComandoCrearConsultorio> validator;

    public CasoDeUsoCrearConsultorio(
        IRepositorioConsultorios repositorio, 
        IUnidadDeTrabajo unidadDeTrabajo,
        IValidator<ComandoCrearConsultorio> validator
    )
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
        this.validator = validator;
    }



    public async Task<Guid> Handle(ComandoCrearConsultorio comando)
    {
        // Lógica para crear un consultorio - Orquestación del dominio
        // Por ejemplo, validar datos, guardar en base de datos, etc.
        // Simulación de creación y retorno de un ID único para el consultorio creado
        var resultadoValidacion = await validator.ValidateAsync(comando);
        if (!resultadoValidacion.IsValid)
        {
            //Excepcion personalizada
            throw new ExcepcionDeValidacion(resultadoValidacion);
        }


        var consultorio = new Consultorio(comando.Nombre);
        try
        {
            var respuesta = await _repositorio.Agregar(consultorio);
            await _unidadDeTrabajo.Persistir();
            return respuesta.Id;

        }
        catch (Exception ex)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }

    }
}
