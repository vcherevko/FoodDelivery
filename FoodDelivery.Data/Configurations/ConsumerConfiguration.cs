using FoodDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDelivery.Data.Configurations;

public class ConsumerConfiguration : IEntityTypeConfiguration<Consumer>
{
	public void Configure(EntityTypeBuilder<Consumer> builder)
	{
		builder.ToTable(nameof(Consumer));
		builder.HasKey(consumer => consumer.Id);

		builder.Property(consumer => consumer.Id).ValueGeneratedOnAdd();
		builder.Property(consumer => consumer.Name).HasMaxLength(60).IsRequired();
		builder.Property(consumer => consumer.Surname).HasMaxLength(60).IsRequired();
		builder.Property(consumer => consumer.Address).HasMaxLength(100).IsRequired();
		builder.Property(consumer => consumer.Email).HasMaxLength(60).IsRequired();
		builder.Property(consumer => consumer.PhoneNumber).HasMaxLength(15).IsRequired();
		builder.Property(consumer => consumer.IsDeleted).HasDefaultValue(false);

		builder.HasMany(consumer => consumer.Orders)
			.WithOne(order => order.Consumer)
			.HasForeignKey(order => order.ConsumerId)
			.HasPrincipalKey(consumer => consumer.Id)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
