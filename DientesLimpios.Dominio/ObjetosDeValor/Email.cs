using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.ObjetosDeValor;

public record Email
{
    public string Valor { get; } = null!;

    public Email(string email)
    {

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(email)} del paciente no puede estar vacío.");
        }
        email = email.Trim();
        if (!email.Contains("@"))
        {
            throw new ExcepcionReglaDeNegocio($"El {nameof(email)} del paciente no es válido.");
        }
        Valor = email;
    }



}
