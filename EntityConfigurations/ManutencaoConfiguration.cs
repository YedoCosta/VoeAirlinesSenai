using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VoeAirlinesSenai.EntityConfiguration;

public class ManutencaoConfiguration : IEntityTypeConfiguration<Manutencao>
{
    public void Configure(EntityTypeBuilder<Manutencao> builder)
    {
        builder.ToTable("Manutencoes");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.DataHora)
                .IsRequired();
        builder.Property(m => m.Observacoes)
                .HasMaxLength(100);
        builder.Property(m => m.Tipo)
                .IsRequired();
        builder.Property(m => m.DescTipo)
                .HasMaxLength(20);
        builder.HasOne(a => a.Aeronave);

    }
}
