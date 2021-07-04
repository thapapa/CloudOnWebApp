using CloudOnWebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CloudOnWebApp.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {


            builder.ToTable("Product");
            builder.Property(pro => pro.ExternalId)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(bd => bd.Code)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(bd => bd.Description)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(bd => bd.Name)
                .IsRequired();
            builder.Property(bd => bd.Barcode)
                .IsRequired();
            builder.Property(bd => bd.RetailPrice)
                .IsRequired();
            builder.Property(bd => bd.WholePrice)
                .IsRequired();
            builder.Property(bd => bd.Discount)
                .IsRequired();

        }
    }
}
