using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente;

public class ValidadorComandoCrearPaciente : AbstractValidator<ComandoCrearPaciente>
{

    public ValidadorComandoCrearPaciente()
    {
        RuleFor(p => p.Nombre)
            .NotEmpty()
            .WithMessage("El campo {PropertyName} es requerido");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido")
            .MaximumLength(100).WithMessage("El campo {PropertyName} no puede exceder los {MaxLength} caracteres")
            .EmailAddress().WithMessage("El campo {PropertyName} debe ser un correo electrónico válido");


    }

}
