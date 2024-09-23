namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class UserProfileDTO : OptionDTO
	{
		public string Username { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public int Reputation { get; set; }

	}
}
