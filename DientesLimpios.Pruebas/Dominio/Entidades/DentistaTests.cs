using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.Entidades;

[TestClass]
public class DentistaTests
{
    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
    public void Constructor_NombreNulo_LanzaExcepcion()
    {
        Email email = new Email("test@example.com");
        new Dentista(null!, email.Valor);
    }

    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
    public void Constructor_EmailInvalido_LanzaExcepcion()
    {
        Email email = new Email("invalid-email");
        new Dentista("pepe", email.Valor);
    }

    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
    public void Constructor_EmailNulo_LanzaExcepcion()
    {
        new Dentista("pepe", null!);
    }

}
