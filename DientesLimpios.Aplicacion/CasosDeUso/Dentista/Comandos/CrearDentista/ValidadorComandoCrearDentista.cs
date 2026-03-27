using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentista.Comandos.CrearDentista;

public class ValidadorComandoCrearDentista : AbstractValidator<ComandoCrearDentista>
{

    public ValidadorComandoCrearDentista()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre del dentista es requerido.")
            .MaximumLength(100).WithMessage("El nombre del dentista no puede exceder los 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El email del dentista es requerido.")
            .EmailAddress().WithMessage("El email del dentista no es válido.");
    }
}
