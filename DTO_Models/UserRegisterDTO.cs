﻿namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class UserRegisterDTO
	{
		public string Username { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public string Password { get; set; }
		public string PasswordRepeat { get; set; }
		public string Email { get; set; }
	}
}
