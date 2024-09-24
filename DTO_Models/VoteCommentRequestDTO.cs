namespace Inzynieria_oprogramowania_API.DTO_Models
{
	public class VoteCommentRequestDTO
	{
		public string UsernName { get; set; }
		public int CommentId { get; set; }
		public string VoteType { get; set; }
		public DateTime VoteTimestamp { get; set; } = DateTime.Now;
	}
}
