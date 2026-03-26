using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DientesLimpios.Persistencia.Configuraciones;

public class PacienteConfig : IEntityTypeConfiguration<Paciente>
{

    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(100);

        builder.ComplexProperty(p => p.Email, action =>
        {
            action.Property(e => e.Valor)
                .HasColumnName("Email") // Opcional: para mapear a una columna específica
                .HasMaxLength(200);
        });



    }
}
