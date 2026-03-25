using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.ObjetosDeValor;


[TestClass]
public class EmailTests
{

    [TestMethod]
    public void Constructor_EmailNulo_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() => new Email(null!));
    }

    [TestMethod]
    public void Constructor_EmailVacio_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() => new Email(string.Empty));
    }

    [TestMethod]
    public void Constructor_EmailSinArroba_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() => new Email("invalidemail.com"));
    }

    [TestMethod]
    public void Constructor_EmailValido_CreaObjetoEmail()
    {
        new Email("test@example.com");
    }


}
