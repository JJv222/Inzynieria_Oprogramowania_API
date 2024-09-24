namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class CommentRequestDTO
	{
		public string UserName { get; set; }
		public int PinId { get; set; }
		public string Description { get; set; }
		public string Zdjecia { get; set; } // Store images as byte arrays (Blob)
	}
}
