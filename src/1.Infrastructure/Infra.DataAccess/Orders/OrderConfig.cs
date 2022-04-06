using Domain.Model.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataAccess.Orders
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");
            builder.HasKey(cr => cr.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasIndex(p => p.Id);

            builder.Property(cr => cr.Monto).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(cr => cr.FechaCompra);

            //builder.HasMany(d => d.Productos)
            //          .WithOne(p => p.Order)
            //          .OnDelete( DeleteBehavior.SetNull);
        }
    }
}
