using DientesLimpios.Aplicacion.Contratos.Notificaciones;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Infraestructura;

public static class RegistroDeServiciosDeInfraestructura
{

    public static IServiceCollection AgregarServiciosDeInfraestructura(this IServiceCollection services)
    {

        services.AddScoped<IServicioNotificaciones, Notificaciones.ServicioCorreo>();

        return services;

    }


}
