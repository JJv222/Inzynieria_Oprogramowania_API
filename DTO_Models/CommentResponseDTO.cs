namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class CommentResponseDTO
	{
		public int ID { get; set; }
		public string Username { get; set; }
		public string Description { get; set; }
		public int LikesUp { get; set; }
		public int LikesDown { get; set; }
		public string Zdjecia { get; set; } // Store images as byte arrays (Blob)
	}
}
