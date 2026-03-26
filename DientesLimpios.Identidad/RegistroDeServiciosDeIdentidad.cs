using DientesLimpios.Aplicacion.Contratos.Identidad;
using DientesLimpios.Identidad.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Identidad;

public static class RegistroDeServiciosDeIdentidad
{

    public static void AgregarServiciosDeIdentidad(this IServiceCollection servicios)
    {
        servicios.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);

        servicios.AddAuthorization(opciones =>
        {
            opciones.AddPolicy("esadmin", politica => politica.RequireClaim("esadmin"));
        });

        servicios.AddDbContext<DientesLimpiosIdentityDbContext>(options =>
            options.UseSqlServer("name=DientesLimpiosIdentityConnectionString"));

        servicios.AddIdentityCore<Usuario>()
            .AddEntityFrameworkStores<DientesLimpiosIdentityDbContext>()
            .AddApiEndpoints();

        servicios.AddTransient<IServicioUsuarios, Servicios.ServicioUsuarios>();
        servicios.AddHttpContextAccessor();

    }

}
