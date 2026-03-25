using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Excepciones;
using FluentValidation;
using NSubstitute;

namespace DientesLimpios.Pruebas.Aplicacion.Utilidades.Mediador;

[TestClass]
public class MediadorSimpleTests
{
    public class RequestFalso : IRequest<string> {
        public required string Nombre { get; set; }
    }

    public class HandlerFalso : IRequestHandler<RequestFalso, string>
    {
        public Task<string> Handle(RequestFalso request)
        {
            return Task.FromResult("Respuesta Falsa");
        }
    }


    public class ValidadorRequestFalso: AbstractValidator<RequestFalso>
    {
        public ValidadorRequestFalso()
        {
            RuleFor(x => x.Nombre).NotEmpty();
        }
    }


    [TestMethod]
    public async Task MediadorSimple_LlamaMetodoHandler()
    {
        // 1.Arrange
        var request = new RequestFalso() { Nombre = "Test" };
        var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();
        //El mediado simple recibe un ServiceProvider para resolver las dependencias
        var serviceProviderMock = Substitute.For<IServiceProvider>();
        serviceProviderMock
            .GetService(typeof(IRequestHandler<RequestFalso, string>))
            .Returns(casoDeUsoMock);
        var mediador = new MediadorSimple(serviceProviderMock);
        // Act
        var respuesta = await mediador.Send(request);
        // Assert
        await casoDeUsoMock.Received(1).Handle(request);
    }


    [TestMethod]
    public async Task Send_SinHandlerregistrado_LAnzaExcepcion()
    {
        // 1.Arrange
        var request = new RequestFalso() { Nombre = "Test" };
        var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalso, string>>();
        //El mediado simple recibe un ServiceProvider para resolver las dependencias
        var serviceProviderMock = Substitute.For<IServiceProvider>();
        //serviceProviderMock
        //    .GetService(typeof(IRequestHandler<RequestFalso, string>))
        //    .Returns(casoDeUsoMock);
        var mediador = new MediadorSimple(serviceProviderMock);
        // Act
        var respuesta = await mediador.Send(request);
        // Assert
        Assert.ThrowsExactly<ExcepcionDeMediador>(async () =>
        {
            await mediador.Send(request);
        });
    }



}