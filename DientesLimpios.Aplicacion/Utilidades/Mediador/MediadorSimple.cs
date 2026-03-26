
using DientesLimpios.Aplicacion.Excepciones;
using FluentValidation;

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
        await RealizarValidaciones(request);

        var tipoCasoDeUso = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        var casoDeUso = serviceProvider.GetService(tipoCasoDeUso);

        if (casoDeUso == null)
        {
            throw new ExcepcionDeMediador($"No se encontró un manejador para la solicitud de tipo {request.GetType().Name}");
        }

        var metodoHandle = tipoCasoDeUso.GetMethod("Handle");

        return await (Task<TResponse>)metodoHandle!.Invoke(casoDeUso, new object[] { request })!;

    }


    public async Task Send(IRequest request)
    {
        await RealizarValidaciones(request);

        var tipoCasoDeUso = typeof(IRequestHandler<,>).MakeGenericType(request.GetType());

        var casoDeUso = serviceProvider.GetService(tipoCasoDeUso);

        if (casoDeUso == null)
        {
            throw new ExcepcionDeMediador($"No se encontró un manejador para la solicitud de tipo {request.GetType().Name}");
        }

        var metodoHandle = tipoCasoDeUso.GetMethod("Handle");

        await (Task)metodoHandle!.Invoke(casoDeUso, new object[] { request })!;


    }





    private async Task RealizarValidaciones(object request)
    {

        var tipoValidador = typeof(IValidator<>).MakeGenericType(request.GetType());
        var validador = serviceProvider.GetService(tipoValidador) as IValidator;
        if (validador != null)
        {
            var metodoValidar = tipoValidador.GetMethod("ValidateAsync");
            var tareaValidar = (Task)metodoValidar!.Invoke(validador,
                new object[] { request, CancellationToken.None })!;
            await tareaValidar.ConfigureAwait(false);
            var resultado = tareaValidar.GetType().GetProperty("Result");
            var validacionResultado = resultado!.GetValue(tareaValidar) as FluentValidation.Results.ValidationResult;
            if (!validacionResultado!.IsValid)
            {
                throw new ExcepcionDeValidacion(validacionResultado);
            }
        }




    }



}
