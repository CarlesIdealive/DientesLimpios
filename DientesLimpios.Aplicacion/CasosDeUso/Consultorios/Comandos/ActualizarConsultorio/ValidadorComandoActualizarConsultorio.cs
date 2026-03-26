using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;

public class ValidadorComandoActualizarConsultorio : AbstractValidator<ComandoActualizarConsultorio>
{
    public ValidadorComandoActualizarConsultorio()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido")
            .Must(id => id != Guid.Empty).WithMessage("El campo {PropertyName} no puede ser un GUID vacío");

        RuleFor(p => p.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyName} es requerido")
            .MaximumLength(100).WithMessage("El campo {PropertyName} no puede exceder los 100 caracteres");
    }


}
