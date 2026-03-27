namespace DientesLimpios.API.Utilidades;

//Extendemos HttpContext para insertar el numero Total de registros en el header de la respuesta,
// para que el cliente pueda usarlo para calcular el numero de paginas
public static class HttpContextExtensions
{

    public static void InsertarPaginacionEnHeader(this HttpContext httpContext, int totalRegistros)
    {
        httpContext.Response.Headers.Append("cantidad-total-Registros", totalRegistros.ToString());
    }


}
