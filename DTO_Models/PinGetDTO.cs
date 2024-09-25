namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class PinGetDTO
	{
		public int ID { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public string UserName { get; set; }
		public string PostType { get; set; }
		public string Category { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int LikesUp { get; set; }
		public int LikesDown { get; set; }
		public string Zdjecia { get; set; } // Store images as byte arrays (Blob)
		public int reputation { get; set; }
	}
}
