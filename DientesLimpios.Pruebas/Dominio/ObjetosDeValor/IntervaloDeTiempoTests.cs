using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Pruebas.Dominio.ObjetosDeValor;

[TestClass]
public class IntervaloDeTiempoTests
{
    [TestMethod]
    public void Constructor_FechaInicioMayorQueFechaFin_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() => new IntervaloDeTiempo(DateTime.Now, DateTime.Now.AddDays(-1)));
    }


    [TestMethod]
    public void Constructor_ParametrosValidos_NoLanzaExcepcion()
    {
        new IntervaloDeTiempo(DateTime.Now, DateTime.Now.AddDays(1));
    }


}
