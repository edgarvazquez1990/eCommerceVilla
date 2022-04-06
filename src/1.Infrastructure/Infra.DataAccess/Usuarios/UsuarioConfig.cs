using Domain.Model.Addresses;
using Domain.Model.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataAccess.Usuarios
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(cr => cr.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasIndex(p => p.Id);

            builder.Property(cr => cr.Nombres).IsRequired();
            builder.Property(cr => cr.PrimerApellido).IsRequired();
            builder.Property(cr => cr.UserName).IsRequired(false);

            builder.HasOne(r => r.Address)
                .WithOne(r => r.Usuario)
                .HasForeignKey<Address>(r => r.UsuarioId);

            builder.HasMany(d => d.Orders)
                      .WithOne(p => p.Usuario)
                      .HasForeignKey(p => p.UsuarioId)
                      .OnDelete(DeleteBehavior.SetNull)
                      .IsRequired(false);
        }
    }
}
