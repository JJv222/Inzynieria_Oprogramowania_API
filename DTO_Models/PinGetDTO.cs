namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class PinGetDTO
	{ 
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public int PostTypeId { get; set; }
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int LikesUp { get; set; }
		public int LikesDown { get; set; }
		public byte[] Zdjecia { get; set; } // Store images as byte arrays (Blob)
	}
}
