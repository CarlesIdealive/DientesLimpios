using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Persistencia.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Persistencia;

public static class RegistroDeServiciosDePersistencia
{
    public static IServiceCollection AgregarServiciosDePersistencia(this IServiceCollection servicios)
    {
        servicios.AddDbContext<DientesLimpiosDbContext>(options =>
            options.UseSqlServer("name=DientesLimpiosConnectionString"));

        servicios.AddScoped<IRepositorioConsultorios, RepositorioConsultorios>();
        servicios.AddScoped<IUnidadDeTrabajo, UnidadesDeTrabajo.UnidadDeTrabajoEFCore>();


        return servicios;
    }


}
