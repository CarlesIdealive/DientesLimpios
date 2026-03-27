using System;
using System.Collections.Generic;
using System.Text;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerDetallePaciente;

public static class MapeadorExtension
{
    public static PacienteDetalleDTO? MapearADTO(this Dominio.Entidades.Paciente paciente)
    {
        if (paciente == null) return null;
        return new PacienteDetalleDTO
        {
            Id = paciente.Id,
            Nombre = paciente.Nombre,
            Email = paciente.Email.Valor
        };
    }

}
