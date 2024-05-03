using FoodDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDelivery.Data.Configurations;

public class CourierConfiguration : IEntityTypeConfiguration<Courier>
{
	public void Configure(EntityTypeBuilder<Courier> builder)
	{
		builder.ToTable(nameof(Courier));
		builder.HasKey(courier => courier.Id);

		builder.Property(courier => courier.Id).ValueGeneratedOnAdd();
		builder.Property(courier => courier.Name).HasMaxLength(60).IsRequired();
		builder.Property(courier => courier.Surname).HasMaxLength(60).IsRequired();
		builder.Property(courier => courier.Coordinates).HasMaxLength(100);
		builder.Property(courier => courier.Email).HasMaxLength(60).IsRequired();
		builder.Property(courier => courier.PhoneNumber).HasMaxLength(15).IsRequired();
		builder.Property(courier => courier.Status).IsRequired();
		builder.Property(courier => courier.IsDeleted).HasDefaultValue(false);

		builder.HasMany(courier => courier.Orders)
			.WithOne(order => order.Courier)
			.HasForeignKey(order => order.CourierId)
			.HasPrincipalKey(courier => courier.Id)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
