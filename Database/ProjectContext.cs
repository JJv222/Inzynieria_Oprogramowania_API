using Microsoft.EntityFrameworkCore;

namespace Inzynieria_oprogramowania_API.Database
{
	public class ProjectContext : DbContext
	{
		protected readonly IConfiguration Configuration;
		private static string Host = "my_host";
		private static string Database = "my_db";
		private static string UserName = "my_user";
		private static string Password = "my_pw";

		public ProjectContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));

	}
}
