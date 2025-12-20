using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;

namespace DientesLimpios.Pruebas.Aplicacion.CasosDeUso.Consultorios;

[TestClass]
public class CasoDeUsoCrearConsultorioTests
{
    private IRepositorioConsultorios repositorio;
    private IValidator<ComandoCrearConsultorio> validador;
    private IUnidadDeTrabajo unidadDeTrabajo;
    private CasoDeUsoCrearConsultorio casoDeUso;


    [TestInitialize]
    public void Setup()
    {
        repositorio = Substitute.For<IRepositorioConsultorios>();
        validador = Substitute.For<IValidator<ComandoCrearConsultorio>>();
        unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();

        casoDeUso = new CasoDeUsoCrearConsultorio(repositorio,unidadDeTrabajo,validador);
    }


    [TestMethod]
    public async Task Handle_ComandoValido_ObtenemosIdConsultorio()
    {
        //1.Preparamos 
        var comando = new ComandoCrearConsultorio { Nombre = "Consultorio A" };
        validador.ValidateAsync(comando).Returns(new ValidationResult());
        var consultorioCreado = new Consultorio(comando.Nombre);
        repositorio.Agregar(Arg.Any<Consultorio>()).Returns(consultorioCreado);
        //3.Ejecutamos la prueba
        var resultado = casoDeUso.Handle(comando);
        //4.Validamos
        await validador.Received(1).ValidateAsync(comando);
        await repositorio.Received(1).Agregar(Arg.Any<Consultorio>());
        await unidadDeTrabajo.Received(1).Persistir();
        Assert.AreNotEqual(Guid.Empty, await resultado);
    }

    [TestMethod]
    public async Task Handle_ComandoInvalido_LanzaExcepcionValidationException()
    {
        //1.Preparamos 
        var comando = new ComandoCrearConsultorio { Nombre = "" };
        var errores = new List<ValidationFailure>
        {
            new ValidationFailure("Nombre", "El nombre no puede estar vacío")
        };
        validador.ValidateAsync(comando).Returns(new ValidationResult(errores));
        //2.Ejecutamos la prueba
        //3.Validamos
        await Assert.ThrowsExceptionAsync<ExcepcionDeValidacion>(async () =>
        {
            await casoDeUso.Handle(comando);
        });
        await repositorio.DidNotReceive().Agregar(Arg.Any<Consultorio>());
    }


}
