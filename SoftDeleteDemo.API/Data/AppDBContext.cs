using Microsoft.EntityFrameworkCore;
using SoftDeleteDemo.API.Data.Models;

namespace SoftDeleteDemo.API.Data
{
	public class AppDBContext : DbContext
	{
		private static readonly SoftDeleteInterceptor _softDeleteInterceptor = new SoftDeleteInterceptor();
		public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<AppTask> AppTasks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.AddInterceptors(_softDeleteInterceptor);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(builder =>
			{
				builder.HasKey(u => u.Id);

				builder.Property(e => e.CreatedAt)
					.HasDefaultValueSql("GETDATE()");

				builder.HasMany(u => u.Tasks)
					.WithOne(t => t.User)
					.HasForeignKey(t => t.UserId)
					.OnDelete(DeleteBehavior.SetNull);

				builder.HasQueryFilter(u => !u.IsDeleted);

				builder.HasIndex(u => u.IsDeleted)
				.HasFilter("IsDeleted = 0");
			});

			modelBuilder.Entity<AppTask>(builder =>
			{
				builder.HasKey(u => u.Id);

				builder.Property(e => e.CreatedAt)
					.HasDefaultValueSql("GETDATE()");

				builder.HasQueryFilter(u => !u.IsDeleted);

				builder.HasIndex(u => u.IsDeleted)
				.HasFilter("IsDeleted = 0");
			});
		}

		//When _softDeleteInterceptor is not used
		/*
		public override int SaveChanges()
		{
			var entries = ChangeTracker.Entries<ISoftDeletable>()
				.Where(e => e.State == EntityState.Deleted);

			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Deleted)
				{
					entry.State = EntityState.Modified;
					(entry.Entity).IsDeleted = true;
					(entry.Entity).DeletedAt = DateTime.UtcNow;
				}
			}
			return base.SaveChanges();
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var entries = ChangeTracker.Entries<ISoftDeletable>()
				.Where(e => e.State == EntityState.Deleted);

			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Deleted)
				{
					entry.State = EntityState.Modified;
					(entry.Entity).IsDeleted = true;
					(entry.Entity).DeletedAt = DateTime.UtcNow;
				}
			}
			return await base.SaveChangesAsync(cancellationToken);
		}
		*/
	}
}
