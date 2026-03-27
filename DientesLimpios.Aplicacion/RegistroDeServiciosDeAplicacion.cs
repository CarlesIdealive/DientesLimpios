using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.BorrarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.ActualizarPaciente;
using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente;
using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerDetallePaciente;
using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;
using DientesLimpios.Aplicacion.Utilidades.Comunes;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Aplicacion;

public static class RegistroDeServiciosDeAplicacion
{
    public static IServiceCollection AgregarServiciosDeAplicacion(this IServiceCollection servicios)
    {
        servicios.AddTransient<IMediator, MediadorSimple>();
        //Consultorios
        servicios.AddScoped<IRequestHandler<ComandoCrearConsultorio, Guid>, CasoDeUsoCrearConsultorio>();
        servicios.AddScoped<IRequestHandler<ComandoActualizarConsultorio>, CasoDeUsoActualizarConsultorio>();
        servicios.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>, CasoDeUsoObtenerDetalleConsutorio>();
        servicios.AddScoped<IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>, CasoDeUsoObtenerListadoConsultorios>();
        servicios.AddScoped<IRequestHandler<ComandoBorrarConsultorio>, CasoDeUsoBorrarConsultorio>();

        //Pacientes
        servicios.AddScoped<IRequestHandler<ComandoCrearPaciente, Guid>, CasoDeUsoCrearPaciente>();
        servicios.AddScoped<IRequestHandler<ComandoActualizarPaciente>, CasoDeUsoActualizarPaciente>();
        servicios.AddScoped<IRequestHandler<ConsultaObtenerDetallePaciente, PacienteDetalleDTO>, CasoDeUsoObtenerDetallesPaciente>();
        servicios.AddScoped<IRequestHandler<ConsultaObtenerListadoPacientes, PaginadoDTO<PacienteListadoDTO>>, CasoDeUsoObtenerListadoPacientes>();



        return servicios;
    }

}
