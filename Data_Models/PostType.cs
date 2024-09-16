namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class PostType
	{
		public int ID { get; set; }
		public string Type { get; set; }
		public ICollection<Pin> Pins { get; set; } // A post type can have many pins
	}

}
