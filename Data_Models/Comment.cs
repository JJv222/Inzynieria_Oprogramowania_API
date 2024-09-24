using Microsoft.Extensions.Hosting;

namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class Comment
	{
		public int ID { get; set; }
		public int UserId { get; set; }
		public int PinId { get; set; }
		public string Description { get; set; }
		public int LikesUp { get; set; }
		public int LikesDown { get; set; }
		public byte[] Zdjecia { get; set; } // Store images as byte arrays (Blob)

		public User User { get; set; } // Navigation property
		public Pin Pin { get; set; } // Navigation property
		public ICollection<VoteComment> Votes { get; set; }
	}
}
