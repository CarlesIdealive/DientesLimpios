using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Enums;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Pruebas.Dominio.Entidades;

[TestClass]
public class CitaTests
{
    private Guid _pacienteId = Guid.NewGuid();
    private Guid _dentistaId = Guid.NewGuid();
    private Guid _consultorioId = Guid.NewGuid();
    private IntervaloDeTiempo _intervaloDeTiempo = new IntervaloDeTiempo(
        DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));


    [TestMethod]
    public void Constructor_CitaValida_EstadoEsProgramada()
    {
        var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervaloDeTiempo);

        Assert.AreEqual(_pacienteId, cita.PacienteId);
        Assert.AreEqual(_dentistaId, cita.DentistaId);
        Assert.AreEqual(_consultorioId, cita.ConsultorioId);
        Assert.AreEqual(_intervaloDeTiempo, cita.IntervaloDeTiempo);
        Assert.AreEqual(EstadoCita.Programada, cita.EstadoCita);
        Assert.AreNotEqual(Guid.Empty, cita.Id);
    }

    [TestMethod]
    public void Constructor_PacienteIdVacio_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() =>
            new Cita(Guid.Empty, _dentistaId, _consultorioId, _intervaloDeTiempo));
    }

    [TestMethod]
    public void Constructor_DentistaIdVacio_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() =>
            new Cita(_pacienteId, Guid.Empty, _consultorioId, _intervaloDeTiempo));
    }

    [TestMethod]
    public void Constructor_ConsultorioIdVacio_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ExcepcionReglaDeNegocio>(() =>
            new Cita(_pacienteId, _dentistaId, Guid.Empty, _intervaloDeTiempo));
    }






}
