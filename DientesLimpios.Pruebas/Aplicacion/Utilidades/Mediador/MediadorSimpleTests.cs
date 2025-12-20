using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using NSubstitute;

namespace DientesLimpios.Pruebas.Aplicacion.Utilidades.Mediador;

[TestClass]
public class MediadorSimpleTests
{
    public class RequestFalso : IRequest<string> { }
    public class HandlerFalso : IRequestHandler<RequestFalso, string>
    {
        public Task<string> Handle(RequestFalso request)
        {
            return Task.FromResult("Respuesta Falsa");
        }

    }


    [TestMethod]
    public async Task MediadorSimple_LlamaMetodoHandler()
    {
        // 1.Arrange
        var request = new RequestFalso();
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
    [ExpectedException(typeof(ExcepcionDeMediador))]
    public async Task Send_SinHandlerregistrado_LAnzaExcepcion()
    {
        // 1.Arrange
        var request = new RequestFalso();
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
    }



}