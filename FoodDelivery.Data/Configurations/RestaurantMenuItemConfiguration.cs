using FoodDelivery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDelivery.Data.Configurations;

public class RestaurantMenuItemConfiguration : IEntityTypeConfiguration<RestaurantMenuItem>
{
	public void Configure(EntityTypeBuilder<RestaurantMenuItem> builder)
	{
		builder.ToTable(nameof(RestaurantMenuItem));
		builder.HasKey(menuItem => menuItem.Id);

		builder.Property(menuItem => menuItem.Id).ValueGeneratedOnAdd();
		builder.Property(menuItem => menuItem.Description).IsRequired(false);
		builder.Property(menuItem => menuItem.Name).IsRequired();
		builder.Property(menuItem => menuItem.RestaurantId).IsRequired();
		builder.Property(menuItem => menuItem.Price).IsRequired();
		builder.Property(menuItem => menuItem.ImagePath).IsRequired(false);
		builder.Property(menuItem => menuItem.IsAvailable).IsRequired();
		builder.Property(menuItem => menuItem.IsDeleted).HasDefaultValue(false);

		builder.HasMany(menuItem => menuItem.OrderItems)
			.WithOne(orderItem => orderItem.RestaurantMenuItem)
			.HasForeignKey(orderItem => orderItem.RestaurantMenuItemId)
			.HasPrincipalKey(menuItem => menuItem.Id)
			.OnDelete(DeleteBehavior.NoAction);
	}
}
