using DientesLimpios.Aplicacion.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios;

public class Repositorio<T> : IRepositorio<T> where T : class
{
    private readonly DientesLimpiosDbContext context;

    public Repositorio(DientesLimpiosDbContext context) => this.context = context;



    public Task Actualizar(T entidad)
    {
        //Patron de Unit of Work - La persistencia no la hacen los metodos
        context.Update(entidad);
        return Task.CompletedTask;
    }

    public Task<T> Agregar(T entidad)
    {
        context.Add(entidad);
        return Task.FromResult(entidad);
    }

    public Task Borrar(T entidad)
    {
        context.Remove(entidad);
        return Task.CompletedTask;
    }

    public async Task<int> ObtenerCantidadTotalRegistros()
    {
        return await context.Set<T>().CountAsync();
    }

    public async Task<T?> ObtenerPorId(Guid id)
    {
        var entidad = await context.FindAsync<T>(id);
        return entidad;
    }

    public async Task<IEnumerable<T>> ObtenerTodos()
    {
        return await context.Set<T>().ToListAsync();
    }

}
