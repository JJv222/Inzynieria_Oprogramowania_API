namespace Inzynieria_oprogramowania_API.Data_Models
{
	public class VotePost
	{
		public int Id { get; set; }             // Klucz główny
		public int UserId { get; set; }          // ID użytkownika
		public int PinId { get; set; }           // ID posta (Pina)
		public string VoteType { get; set; }     // Typ głosu (likeUp, likeDown)
		public DateTime VoteTimestamp { get; set; } = DateTime.Now; // Czas oddania głosu

		// Relacje
		public User User { get; set; }           // Nawigacja do użytkownika
		public Pin Pin { get; set; }             // Nawigacja do posta (Pina)
	}

}
