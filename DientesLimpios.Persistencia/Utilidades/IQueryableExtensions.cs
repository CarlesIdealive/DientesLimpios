namespace DientesLimpios.Persistencia.Utilidades;

public static class IQueryableExtensions
{
    //Metodo de extension porque: 
    // - Permite agregar funcionalidad a tipos existentes sin modificar su código fuente.
    //Un metodo de extension se consigue:
    // - Definiendo un método estático dentro de una clase estática.
    // - El primer parámetro del método de extensión debe tener el modificador "this" seguido del tipo al que se desea extender.
    public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, int pagina, int registrosPorPagina)
    {
        var skip = (pagina - 1) * registrosPorPagina;
        return queryable
                .Skip(skip)
                .Take(registrosPorPagina);
    }


}
