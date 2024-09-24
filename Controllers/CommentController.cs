using Inzynieria_oprogramowania_API.Data_Models;
using Inzynieria_oprogramowania_API.Database;
using Inzynieria_oprogramowania_API.DTO_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inzynieria_oprogramowania_API.Controllers
{
	[Route("api/[controller]")]
	public class CommentController : Controller
	{
		private readonly ProjectContext projectContext;
		public CommentController(ProjectContext projectContext)
		{
			this.projectContext = projectContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetComments([FromQuery] string postId)
		{
			// Pobranie danych z bazy
			var comments = await projectContext.Comments
				.Include(c => c.User)
				.Where(c => c.PinId.Equals(int.Parse(postId)))
				.Select(c => new CommentResponseDTO
				{
					ID = c.ID,
					Username = c.User.Username,
					Description = c.Description,
					LikesUp = c.LikesUp,
					LikesDown = c.LikesDown,
					Zdjecia = c.Zdjecia != null ? Convert.ToBase64String(c.Zdjecia) : null
				})
			.ToListAsync();

			return Ok(comments);
		}

		[HttpPost]
		public async Task<IActionResult> AddComment([FromBody] CommentRequestDTO commentRequestDTO)
		{
			// Pobranie danych z bazy
			var pin = await projectContext.Pins
				.FirstOrDefaultAsync(p => p.ID.Equals(commentRequestDTO.PinId));

			if (pin == null)
			{
				return NotFound("Pin not found.");
			}

			var userId = await projectContext.Users
				.Where(u => u.Username.Equals(commentRequestDTO.UserName))
				.Select(u => u.ID)
				.FirstOrDefaultAsync();
			if (userId == null)
			{
				return NotFound("User not found.");
			}
			// Dodanie komentarza
			var comment = new Comment
			{
				UserId = userId,
				PinId = commentRequestDTO.PinId,
				Description = commentRequestDTO.Description,
				LikesUp = 0,
				LikesDown = 0,
				Zdjecia = commentRequestDTO.Zdjecia != null ? Convert.FromBase64String(commentRequestDTO.Zdjecia) : null
			};

			projectContext.Comments.Add(comment);
			await projectContext.SaveChangesAsync();

			return Ok("Comment added.");
		}
	}
}
