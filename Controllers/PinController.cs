using Inzynieria_oprogramowania_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

		[HttpGet]
		public async Task<IActionResult> GetPins()
		{
			// Pobranie danych z bazy
			var pins = await projectContext.Pins.ToListAsync();

			// Konwersja obrazów z formatu byte[] na base64
			var pinsWithBase64Images = pins.Select(pin => new
			{
				pin.ID,
				pin.UserId,
				pin.Longitude,
				pin.Latitude,
				pin.PostTypeId,
				pin.CategoryId,
				pin.Title,
				pin.Description,
				pin.LikesUp,
				pin.LikesDown,
				Zdjecia = pin.Zdjecia != null ? Convert.ToBase64String(pin.Zdjecia) : null  // Konwersja na base64
			});

			return Ok(pinsWithBase64Images);
		}
	}
}
