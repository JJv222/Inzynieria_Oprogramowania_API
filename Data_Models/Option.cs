namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class Option
	{
		public int ID { get; set; }
		public int UserId { get; set; }
		public string Sms { get; set; }
		public string Email { get; set; }
		public string LocationBased { get; set; }
	}
}
