using Inzynieria_oprogramowania_API.Data_Models;
using Inzynieria_oprogramowania_API.Database;
using Inzynieria_oprogramowania_API.DTO_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Inzynieria_oprogramowania_API.Controllers
{
	[Route("api/[controller]")]
	public class PinController : Controller
	{
		private readonly ProjectContext projectContext;
		public PinController(ProjectContext projectContext)
		{
			this.projectContext = projectContext;
		}

		[HttpGet("details")]
		public async Task<IActionResult> GetPinForDetails([FromQuery] string postId)
		{
			// Pobranie danych z bazy
			var pin = await projectContext.Pins
				.Include(p => p.Category)
				.Include(p => p.User)
				.Include(p => p.PostType)
				.FirstOrDefaultAsync(p => p.ID.Equals(int.Parse(postId)));

			var result = new PinGetDTO
			{
				ID = pin.ID,
				Longitude = pin.Longitude,
				Latitude = pin.Latitude,
				UserName = pin.User.Username,
				PostType = pin.PostType.Type ?? "Unknown",
				Category = pin.Category?.Type ?? "Unknown",
				Title = pin.Title,
				Description = pin.Description,
				LikesUp = pin.LikesUp,
				LikesDown = pin.LikesDown,
				Zdjecia = pin.Zdjecia != null ? Convert.ToBase64String(pin.Zdjecia) : null,
				reputation = pin.User.Reputation
			};

			return Ok(result);
		}

		[HttpGet]
		public async Task<IActionResult> GetPins([FromQuery] string postType)
		{
			// Znajdź PostTypeId na podstawie postType
			var postTypeFounded = await projectContext.PostTypes
				.FirstOrDefaultAsync(pt => pt.Type == postType);

			if (postTypeFounded == null)
			{
				return NotFound("PostType not found.");
			}
			// Pobranie danych z bazy
			var pins = await projectContext.Pins
				.Include(p => p.Category)
				.Include(p => p.User)
				.Where(p => p.PostTypeId.Equals(postTypeFounded.ID))
				.ToListAsync();

			var result = pins.Select(x => new PinRequestAllDTO
			{
				ID = x.ID,
				Longitude = x.Longitude,
				Latitude = x.Latitude,
				UserName = x.User.Username,
				PostType = postType,
				Category = x.Category?.Type ?? "Unknown",
				Title = x.Title,
				Description = x.Description,
				LikesUp = x.LikesUp,
				LikesDown = x.LikesDown,
				reputation = x.User.Reputation
			}).ToList();

			return Ok(result);
		}


		[HttpPost("AddPin")]
		public async Task<IActionResult> AddComment([FromBody] PinRequestDTO pinRequest)
		{

			var userId = await projectContext.Users
				.Where(u => u.Username.Equals(pinRequest.UserName))
				.Select(u => u.ID)
				.FirstOrDefaultAsync();
			if (userId == null)
			{
				return NotFound("User not found.");
			}
			var categoryId = await projectContext.Categories
				.Where(c => c.Type.Equals(pinRequest.Category))
				.Select(c => c.ID)
				.FirstOrDefaultAsync();
			if (categoryId == null)
			{
				return NotFound("Category not found.");
			}
			var postTypeId = await projectContext.PostTypes
				.Where(pt => pt.Type.Equals(pinRequest.PostType))
				.Select(pt => pt.ID)
				.FirstOrDefaultAsync();
			if (postTypeId == null)
			{
				return NotFound("PostType not found.");
			}
			// Dodanie pinu
			var pin = new Pin
			{
				UserId = userId,
				Longitude = pinRequest.Longitude,
				Latitude = pinRequest.Latitude,
				PostTypeId = postTypeId,
				CategoryId = categoryId,
				Title = pinRequest.Title,
				Description = pinRequest.Description,
				LikesUp = 0,
				LikesDown = 0,
				CreatedDate = new DateOnly(),
				Zdjecia = pinRequest.Zdjecia != null ? Convert.FromBase64String(pinRequest.Zdjecia) : new Byte[64]
			};
			projectContext.Pins.Add(pin);
			projectContext.SaveChanges();


			return Ok("Comment added.");
		}

	}
}
