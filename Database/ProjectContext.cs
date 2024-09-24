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
		public DbSet<VotePost> VotesPost { get; set; }
		public DbSet<VoteComment> VotesComment { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Relacja: Pin -> User (wiele Pin do jednego User)
			modelBuilder.Entity<User>()
				   .HasOne(u => u.Option)
				   .WithOne()
				   .HasForeignKey<User>(u => u.OptionId)
				   .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Pin>()
				.HasOne(p => p.User)
				.WithMany(u => u.Pins)
				.HasForeignKey(p => p.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Pin>()
				.HasOne(p => p.Category)
				.WithMany(c => c.Pins)
				.HasForeignKey(p => p.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Pin>()
				.HasOne(p => p.PostType);

			modelBuilder.Entity<Comment>()
				.HasOne(c => c.User)
				.WithMany(u => u.Comments)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Comment>()
				.HasOne(c => c.Pin)
				.WithMany(p => p.Comments)
				.HasForeignKey(c => c.PinId)
				.OnDelete(DeleteBehavior.Cascade);

			// Relacja: Votes -> User (wiele Votes do jednego User)
			modelBuilder.Entity<VotePost>()
				.HasOne(v => v.User)
				.WithMany(u => u.Votes) // Zakładam, że dodasz kolekcję Votes w User
				.HasForeignKey(v => v.UserId)
				.OnDelete(DeleteBehavior.Cascade); // Kaskadowe usuwanie

			// Relacja: Votes -> Pin (wiele Votes do jednego Pin)
			modelBuilder.Entity<VotePost>()
				.HasOne(v => v.Pin)
				.WithMany(p => p.Votes) // Zakładam, że dodasz kolekcję Votes w Pin
				.HasForeignKey(v => v.PinId)
				.OnDelete(DeleteBehavior.Cascade); // Kaskadowe usuwanie

			// Relacja: VotesComment -> User (wiele VotesComment do jednego User)
			modelBuilder.Entity<VoteComment>()
				.HasOne(v => v.User)
				.WithMany(u => u.VoteComments) // Zakładam, że dodasz kolekcję VotesComment w User
				.HasForeignKey(v => v.UserId)
				.OnDelete(DeleteBehavior.Cascade); // Kaskadowe usuwanie

			modelBuilder.Entity<VoteComment>()
				.HasOne(v => v.Comment)
				.WithMany(c => c.Votes) // Zakładam, że dodasz kolekcję Votes w Comment
				.HasForeignKey(v => v.CommentId)
				.OnDelete(DeleteBehavior.Cascade); // Kaskadowe usuwanie

			base.OnModelCreating(modelBuilder);
		}


	}

}
