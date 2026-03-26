using DientesLimpios.Aplicacion.Excepciones;
using System.Net;
using System.Text.Json;

namespace DientesLimpios.API.Middlewares;

public class ManejadorExcepcionesMiddleware
{
    private readonly RequestDelegate _next;

    public ManejadorExcepcionesMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            //Invoco el siguiente middleware en la cadena
            await _next(context);
        }
        catch (Exception ex)
        {
            // Si ocurre una excepción, capturo el error y devuelvo una respuesta JSON con el mensaje de error
            // Aquí puedes personalizar la respuesta según el tipo de excepción o el entorno (desarrollo vs producción)
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError; // 500
            context.Response.ContentType = "application/json";
            string? respuesta;
            switch (ex)
            {
                case ExcepcionNoEncontrado:
                    statusCode = HttpStatusCode.NotFound; // 404
                    respuesta = ex.Message;
                    break;
                case ExcepcionDeValidacion:
                    statusCode = HttpStatusCode.BadRequest;
                    respuesta = JsonSerializer.Serialize(((ExcepcionDeValidacion)ex).ErroresDeValidacion);
                    break;
                case ApplicationException:
                    statusCode = HttpStatusCode.BadRequest; // 400
                    respuesta = ex.Message;
                    break;
                default:
                    respuesta = "Ocurrió un error inesperado.";
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(respuesta);
        }
    }

}



//Creamos una clase de extensión para facilitar la adición del middleware en el pipeline de ASP.NET Core
public static class ManejadorExcepcionesMiddlewareExtensions
{
    public static IApplicationBuilder UseManejadorExcepciones(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ManejadorExcepcionesMiddleware>();
    }
}
