using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.BorrarPaciente;

public class ValidadorComandoBorrarPaciente : AbstractValidator<ComandoBorrarPaciente>
{

    public ValidadorComandoBorrarPaciente()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es obligatorio");
    }

}
