using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OngsLives.Domain.Entidades;

public class OngFinanceiroConfiguration : IEntityTypeConfiguration<OngFinanceiro>
{
    public void Configure(EntityTypeBuilder<OngFinanceiro> builder)
    {
        builder.ToTable("TB_OngFinanceiros");
        builder.HasKey(x => x.Id);

        builder.Property(p => p.IdOng)
        .HasColumnName("IdOng")
        .IsRequired()
        .HasColumnType("int");

        builder.Property(e => e.Tipo)
        .HasColumnName("Tipo")
        .IsRequired()
        .HasColumnType("nvarchar(50)");

        builder.Property(e => e.Data)
        .HasColumnName("Data")
        .IsRequired()
        .HasColumnType("datetime");

        builder.Property(e => e.Valor)
        .HasColumnName("Valor")
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Origem)
        .HasColumnName("Origem")
        .IsRequired()
        .HasColumnType("nvarchar(100)");

        builder.Property(e => e.CriadoEm)
        .HasColumnName("CriadoEm")
        .IsRequired()
        .HasColumnType("datetime")
        .HasDefaultValueSql("GETDATE()");
    }
}