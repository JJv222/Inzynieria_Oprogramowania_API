using Microsoft.Extensions.Hosting;

namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class Pin
	{
		public int ID { get; set; }
		public int UserId { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public int PostTypeId { get; set; }
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int LikesUp { get; set; }
		public int LikesDown { get; set; }
		public byte[] Zdjecia { get; set; } // Store images as byte arrays (Blob)


		public User User { get; set; } // Navigation property
		public ICollection<Comment> Comments { get; set; } // A pin can have many comments
		public PostType PostType { get; set; } // Navigation property
		public Category Category { get; set; } // Navigation property

	}

}
