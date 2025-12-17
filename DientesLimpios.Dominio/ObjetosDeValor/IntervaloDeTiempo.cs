using DientesLimpios.Dominio.Excepciones;

namespace DientesLimpios.Dominio.ObjetosDeValor;

public record IntervaloDeTiempo
{
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }

    public IntervaloDeTiempo(DateTime inicio, DateTime fin)
    {
        if (fin < inicio)
            throw new ExcepcionReglaDeNegocio("La fecha de fin debe ser posterior a la fecha de inicio.");

        Inicio = inicio;
        Fin = fin;
    }


}
