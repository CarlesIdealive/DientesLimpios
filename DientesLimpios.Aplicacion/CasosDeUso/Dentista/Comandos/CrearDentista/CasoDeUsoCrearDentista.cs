using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using System;
using System.Collections.Generic;
using System.Text;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentista.Comandos.CrearDentista;

public class CasoDeUsoCrearDentista : IRequestHandler<ComandoCrearDentista, Guid>
{
    private readonly IRepositorioDentistas repositorioDentistas;
    private readonly IUnidadDeTrabajo unidadDeTrabajo;

    public CasoDeUsoCrearDentista(IRepositorioDentistas repositorioDentistas, IUnidadDeTrabajo unidadDeTrabajo)
    {
        this.repositorioDentistas = repositorioDentistas;
        this.unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task<Guid> Handle(ComandoCrearDentista request)
    {
        var dentista = new Dominio.Entidades.Dentista(request.Nombre, request.Email);
        try
        {
            await repositorioDentistas.Agregar(dentista);
            await unidadDeTrabajo.Persistir();
            return dentista.Id;
        }
        catch (Exception)
        {
            await unidadDeTrabajo.Reversar();
            throw;
        }

    }

}
