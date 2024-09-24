using Inzynieria_oprogramowania_API.Data_Models;
using Inzynieria_oprogramowania_API.Database;
using Inzynieria_oprogramowania_API.DTO_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inzynieria_oprogramowania_API.Controllers
{
	public class VoteController : Controller
	{
		private readonly ProjectContext projectContext;
		public VoteController(ProjectContext projectContext)
		{
			this.projectContext = projectContext;
		}

		[HttpPost("api/Pin/votePost")]
		public IActionResult VotePost([FromBody] VotePostRequestDTO request)
		{
			// Sprawdź, czy użytkownik już głosował na ten post
			var userId = projectContext.Users.FirstOrDefault(u => u.Username == request.UsernName).ID;

			var existingVote = projectContext.VotesPost
				.FirstOrDefault(v => v.PinId == request.PinId && v.UserId == userId);

			if (existingVote != null)
			{
				existingVote.VoteType = request.VoteType;
				// Zaktualizuj licznik głosów w tabeli postów
				var post = projectContext.Pins.FirstOrDefault(p => p.ID == request.PinId);
				if (post != null)
				{
					if (request.VoteType == "likeUp")
					{
						post.LikesUp += 1;
						post.LikesDown -= 1;
					}
					else if (request.VoteType == "likeDown")
					{
						post.LikesDown += 1;
						post.LikesUp -= 1;
					}
				}

			}
			else
			{
				// Dodaj głos do bazy danych
				var newVote = new VotePost
				{
					PinId = request.PinId,
					UserId = userId,
					VoteType = request.VoteType,
					VoteTimestamp = request.VoteTimestamp
				};
				projectContext.VotesPost.Add(newVote);
				// Zaktualizuj licznik głosów w tabeli postów
				var post = projectContext.Pins.FirstOrDefault(p => p.ID == request.PinId);
				if (post != null)
				{
					if (request.VoteType == "likeUp")
					{
						post.LikesUp += 1;
					}
					else if (request.VoteType == "likeDown")
					{
						post.LikesDown += 1;
					}
				}
			}



			projectContext.SaveChanges();
			return Ok("Vote successfully recorded.");
		}

		[HttpPost("api/Pin/voteComment")]
		public IActionResult VoteComment([FromBody] VoteCommentRequestDTO request)
		{
			// Sprawdź, czy użytkownik już głosował na ten post
			var userId = projectContext.Users.FirstOrDefault(u => u.Username == request.UsernName).ID;

			var existingVote = projectContext.VotesComment
				.FirstOrDefault(v => v.CommentId == request.CommentId && v.UserId == userId);

			if (existingVote != null)
			{
				existingVote.VoteType = request.VoteType;
				// Zaktualizuj licznik głosów w tabeli postów
				var comment = projectContext.Comments.FirstOrDefault(p => p.ID == request.CommentId);
				if (comment != null)
				{
					if (request.VoteType == "likeUp")
					{
						comment.LikesUp += 1;
						comment.LikesDown -= 1;
					}
					else if (request.VoteType == "likeDown")
					{
						comment.LikesDown += 1;
						comment.LikesUp -= 1;
					}
				}

			}
			else
			{
				// Dodaj głos do bazy danych
				var newVote = new VoteComment
				{
					CommentId = request.CommentId,
					UserId = userId,
					VoteType = request.VoteType,
					VoteTimestamp = request.VoteTimestamp
				};
				projectContext.VotesComment.Add(newVote);
				// Zaktualizuj licznik głosów w tabeli postów
				var comment = projectContext.Comments.FirstOrDefault(p => p.ID == request.CommentId);
				if (comment != null)
				{
					if (request.VoteType == "likeUp")
					{
						comment.LikesUp += 1;
					}
					else if (request.VoteType == "likeDown")
					{
						comment.LikesDown += 1;
					}
				}
			}



			projectContext.SaveChanges();
			return Ok("Vote successfully recorded.");
		}
	}
}
