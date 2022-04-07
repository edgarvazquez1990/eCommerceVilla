using Domain.Model.ProductsOrdes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.DataAccess.ProductsOrders
{
    public class ProductOrderConfig : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.ToTable("product_order");
            builder.HasKey(cr => new { cr.ProductId, cr.OrderId });

            builder.HasOne(cr => cr.Product)
                .WithMany(x => x.ProductsOrders)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();

            builder.HasOne(cr => cr.Order)
                .WithMany(x => x.ProductsOrders)
                .HasForeignKey(x => x.OrderId)
                .IsRequired();
        }
    }
}
