using FW.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FW.Infrastructure;

public class FWDbContext : DbContext
{
	public FWDbContext(DbContextOptions<FWDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(FWDbContext).Assembly);
	}
}
