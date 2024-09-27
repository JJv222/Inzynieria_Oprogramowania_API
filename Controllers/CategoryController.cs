using Inzynieria_oprogramowania_API.Database;
using Inzynieria_oprogramowania_API.DTO_Models;
using Microsoft.AspNetCore.Mvc;

namespace Inzynieria_oprogramowania_API.Controllers
{
	[Route("api/[controller]")]
	public class CategoryController : Controller
	{
		private readonly ProjectContext projectContext;
		public CategoryController(ProjectContext projectContext)
		{
			this.projectContext = projectContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			// Pobranie danych z bazy
			List<string> categories = new List<string>();
			projectContext.Categories.ToList().ForEach(x =>
				categories.Add(x.Type));

			return Ok(categories);
		}
	}
}
