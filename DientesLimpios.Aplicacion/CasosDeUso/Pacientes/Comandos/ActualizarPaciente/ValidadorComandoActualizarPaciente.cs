using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.ActualizarPaciente;

public class ValidadorComandoActualizarPaciente : AbstractValidator<ComandoActualizarPaciente>
{

    public ValidadorComandoActualizarPaciente()
    {
        RuleFor(p => p.Id)
        .NotEmpty().WithMessage("El campo {PropertyName} es requerido");

        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido")
            .MaximumLength(100).WithMessage("El campo {PropertyName} no puede exceder los 100 caracteres");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido")
            .EmailAddress().WithMessage("El campo {PropertyName} debe ser una dirección de correo electrónico válida");
    }
}
