using Inzynieria_oprogramowania_API.Data_Models;
using Microsoft.EntityFrameworkCore;

namespace Inzynieria_oprogramowania_API.Database
{
	public class ProjectContext : DbContext
	{
		protected readonly IConfiguration Configuration;

		public ProjectContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));

		public DbSet<User> Users { get; set; }
		public DbSet<Pin> Pins { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Option> Options { get; set; }
		public DbSet<PostType> PostTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Relacja: Pin -> User (wiele Pin do jednego User)
			modelBuilder.Entity<Pin>()
				.HasOne(p => p.User)
				.WithMany(u => u.Pins)
				.HasForeignKey(p => p.UserId)
				.OnDelete(DeleteBehavior.Cascade); // Kaskadowe usuwanie

			// Relacja: Pin -> Category (wiele Pin do jednej Category)
			modelBuilder.Entity<Pin>()
				.HasOne(p => p.Category)
				.WithMany(c => c.Pins)
				.HasForeignKey(p => p.CategoryId)
				.OnDelete(DeleteBehavior.Restrict); // Brak usuwania kaskadowego

			// Relacja: Pin -> PostType (wiele Pin do jednego PostType)
			modelBuilder.Entity<Pin>()
				.HasOne(p => p.PostType);

			// Relacja: Comment -> User (wiele Comment do jednego User)
			modelBuilder.Entity<Comment>()
				.HasOne(c => c.User)
				.WithMany(u => u.Comments)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			// Relacja: Comment -> Pin (wiele Comment do jednego Pin)
			modelBuilder.Entity<Comment>()
				.HasOne(c => c.Pin)
				.WithMany(p => p.Comments)
				.HasForeignKey(c => c.PinId)
				.OnDelete(DeleteBehavior.Cascade);

			// Relacja: Option -> User (wiele User do jednej Option)
			modelBuilder.Entity<User>()
				.HasOne(u => u.Option)
				.WithMany(o => o.Users)
				.HasForeignKey(u => u.OptionId)
				.OnDelete(DeleteBehavior.Restrict);

			// Opcjonalne pole w User -> Option (nullable)
			modelBuilder.Entity<User>()
				.HasOne(u => u.Option)
				.WithMany(o => o.Users)
				.HasForeignKey(u => u.OptionId)
				.IsRequired(false);

			// Inne opcje lub indeksy można dodać tutaj

			base.OnModelCreating(modelBuilder);
		}

	}

}
