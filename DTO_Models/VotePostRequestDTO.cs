namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class VotePostRequestDTO
	{
		public string UsernName { get; set; }
		public int PinId { get; set; }
		public string VoteType { get; set; }
		public DateTime VoteTimestamp { get; set; } = DateTime.Now;
	}
}
