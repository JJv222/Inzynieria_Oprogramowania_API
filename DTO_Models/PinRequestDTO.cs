namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class PinRequestDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public string PostType { get; set; }
		public string UserName { get; set; }
		public string Zdjecia { get; set; } // Store images as byte arrays (Blob)
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
}
