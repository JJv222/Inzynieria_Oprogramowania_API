using Microsoft.Extensions.Hosting;

namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class User
	{
		public int ID { get; set; }
		public int? OptionId { get; set; } // Nullable foreign key if not required
		public string Name { get; set; }
		public string Email { get; set; }
		public string? Phone { get; set; }
		public string Password { get; set; } // Assume SHA2 hashed password
		public string Role { get; set; }

		public Option Option { get; set; } // Navigation property
		public ICollection<Pin> Pins { get; set; } // A user can have many pins
		public ICollection<Comment> Comments { get; set; } // A user can have many comments
	}

}
