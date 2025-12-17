using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Pruebas.Dominio.Entidades;

[TestClass]
public class PacienteTests
{
    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
    public void CrearPaciente_ConNombreValido_YEmailNoValido_LanzaExcepcion()
    {
        new Paciente("Juan Perez", "notvalid.com");
    }

    [TestMethod]
    [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
    public void CrearPaciente_ConNombreVacio_LanzaExcepcion()
    {
        new Paciente(null!, "valid@test.com");
    }




}
