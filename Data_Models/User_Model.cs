namespace Inzynieria_oprogramowania_API.Data_Models
{
	abstract public class User_Model
	{
		public int id { get; set; }
		public string name { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string role { get; set; }
		public DateTime createdAt { get; set; }
		public DateTime updatedAt { get; set; }
		public DateTime deletedAt { get; set; }


		//FK
		public int? postId { get; set; }
		public 
	}
}
