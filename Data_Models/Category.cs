namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class Category
	{
		public int ID { get; set; }
		public string Type { get; set; }
		public ICollection<Pin> Pins { get; set; } // A category can have many pins

	}

}
