namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class Option
	{
		public int ID { get; set; }
		public int UserId { get; set; }
		public string OptionName { get; set; } // Assuming "N opcji" is a string option name -> zamienic na N pól z opcjami
		public ICollection<User> Users{ get; set; } // Navigation property
	}
}
