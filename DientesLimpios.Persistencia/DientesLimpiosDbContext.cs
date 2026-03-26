using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia;

public class DientesLimpiosDbContext : DbContext
{
    //Declarar el DbContextsOptions de esta forma permite tener multiples dbContext en el mismo proyecto,
    //cada uno con su propia configuración.
    public DientesLimpiosDbContext(DbContextOptions<DientesLimpiosDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DientesLimpiosDbContext).Assembly);

    }


    public DbSet<Consultorio> Consultorios { get; set; }


}
