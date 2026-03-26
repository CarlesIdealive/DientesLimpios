using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.BorrarConsultorio;

public class ValidadorComandoBorrarConsultorio : AbstractValidator<ComandoBorrarConsultorio>
{
    public ValidadorComandoBorrarConsultorio()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El Id es obligatorio.");
    }
}
