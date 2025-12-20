namespace DientesLimpios.Aplicacion.Utilidades.Mediador;

// Representa el manejador de la solicitud que le vamos a enviar al mediador
// (manejador de comandos o consultas)
// TRequest: Tipo de solicitud que vamos a manejar de tipo IRequest<TResponse>
// TResponse: Tipo de respuesta que vamos a devolver
public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    // Maneja la solicitud y devuelve una respuesta asincrónica
    // Se utiliza en el caso de uso para procesar la solicitud
    Task<TResponse> Handle(TRequest request);

}
