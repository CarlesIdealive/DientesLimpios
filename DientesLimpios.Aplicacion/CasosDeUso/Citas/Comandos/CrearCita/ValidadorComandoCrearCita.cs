using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CrearCita;

public class ValidadorComandoCrearCita : AbstractValidator<ComandoCrearCita>
{
    public ValidadorComandoCrearCita()
    {
        RuleFor(x => x.PacienteId)
            .NotEmpty().WithMessage("El ID del paciente es requerido.");
        RuleFor(x => x.DentistaId)
            .NotEmpty().WithMessage("El ID del dentista es requerido.");
        RuleFor(x => x.ConsultorioId)
            .NotEmpty().WithMessage("El ID del consultorio es requerido.");

        RuleFor(x => x.FechaInicio)
            .NotEmpty().WithMessage("La fecha de inicio es requerida.")
            .Must(fecha => fecha > DateTime.UtcNow).WithMessage("La fecha de inicio no puede ser en el pasado.")
            .GreaterThan(x => x.FechaFin).WithMessage("La fecha Final debe ser posterior a la FEcha de Inicio ");


    }

}
