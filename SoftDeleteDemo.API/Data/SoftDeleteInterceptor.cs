using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SoftDeleteDemo.API.Data.Models;

namespace SoftDeleteDemo.API.Data
{
	public class SoftDeleteInterceptor : SaveChangesInterceptor
	{
		public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
		{
			if (eventData.Context is null)
			{
				return base.SavingChanges(eventData, result);
			}

			var entries = eventData.Context.ChangeTracker
				.Entries<ISoftDeletable>()
				.Where(e => e.State == EntityState.Deleted);

			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Deleted)
				{
					entry.State = EntityState.Modified;
					entry.Entity.IsDeleted = true;
					entry.Entity.DeletedAt = DateTime.UtcNow;
				}
			}
			return base.SavingChanges(eventData, result);
		}

		public override ValueTask<InterceptionResult<int>> SavingChangesAsync
			(DbContextEventData eventData, 
			InterceptionResult<int> result, 
			CancellationToken cancellationToken = default)
		{
			if (eventData.Context is null)
			{
				return base.SavingChangesAsync(eventData, result, cancellationToken);
			}

			var entries = eventData.Context.ChangeTracker
				.Entries<ISoftDeletable>()
				.Where(e => e.State == EntityState.Deleted);

			foreach (var entry in entries)
			{
				entry.State = EntityState.Modified;
				entry.Entity.IsDeleted = true;
				entry.Entity.DeletedAt = DateTime.UtcNow;
			}

			return base.SavingChangesAsync(eventData, result, cancellationToken);
		}
	}
}
