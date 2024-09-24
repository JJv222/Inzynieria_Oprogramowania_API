namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class VoteComment
	{
		public int Id { get; set; }             // Klucz główny
		public int UserId { get; set; }          // ID użytkownika
		public int CommentId { get; set; }           // ID commentu 
		public string VoteType { get; set; }     // Typ głosu (likeUp, likeDown)
		public DateTime VoteTimestamp { get; set; } = DateTime.Now; // Czas oddania głosu
		public User User { get; set; }           // Nawigacja do użytkownika
		public Comment Comment{ get; set; }             // Nawigacja do commentu
	}
}
