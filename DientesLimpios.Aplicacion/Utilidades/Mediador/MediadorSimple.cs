
namespace DientesLimpios.Aplicacion.Utilidades.Mediador;

public class MediadorSimple : IMediator
{
    private readonly IServiceProvider serviceProvider;

    public MediadorSimple(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }


    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var tipoCasoDeUso = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        var casoDeUso = serviceProvider.GetService(tipoCasoDeUso);

        if (casoDeUso == null)
        {
            throw new InvalidOperationException($"No se encontró un manejador para la solicitud de tipo {request.GetType().Name}");
        }

        var metodoHandle = tipoCasoDeUso.GetMethod("Handle");

        return await (Task<TResponse>)metodoHandle!.Invoke(casoDeUso, new object[] { request })!;

    }


}
