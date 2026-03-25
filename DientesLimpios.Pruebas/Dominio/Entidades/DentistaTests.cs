using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.Entidades;

[TestClass]
public class DentistaTests
{
    [TestMethod]
    public void Constructor_NombreNulo_LanzaExcepcion()
    {
        Email email = new Email("test@example.com");
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() => new Dentista(null!, email.Valor));

    }

    [TestMethod]
    public void Constructor_EmailInvalido_LanzaExcepcion()
    {
        Email email = new Email("invalid-email");
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() => new Dentista("pepe", email.Valor));
    }

    [TestMethod]
    public void Constructor_EmailNulo_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() => new Dentista("pepe", null!));
    }

}
