﻿using FoodDelivery.Domain.Repositories;

namespace FoodDelivery.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly AppDbContext _dbContext;

	public UnitOfWork(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return _dbContext.SaveChangesAsync(cancellationToken);
	}
}
