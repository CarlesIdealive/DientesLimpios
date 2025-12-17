using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.ObjetosDeValor;


[TestClass]
public class EmailTests
{

    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
    public void Constructor_EmailNulo_LanzaExcepcion()
    {
        new Email(null!);
    }

    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
    public void Constructor_EmailVacio_LanzaExcepcion()
    {
        new Email(string.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
    public void Constructor_EmailSinArroba_LanzaExcepcion()
    {
        new Email("invalidemail.com");
    }

    [TestMethod]
    public void Constructor_EmailValido_CreaObjetoEmail()
    {
        new Email("test@example.com");
    }


}
