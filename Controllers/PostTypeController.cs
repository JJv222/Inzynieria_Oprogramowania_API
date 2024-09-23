using Inzynieria_oprogramowania_API.Database;
using Microsoft.AspNetCore.Mvc;

namespace Inzynieria_oprogramowania_API.Controllers
{
	[Route("api/[controller]")]
	public class PostTypeController : Controller
	{
		private readonly ProjectContext projectContext;
		public PostTypeController(ProjectContext projectContext)
		{
			this.projectContext = projectContext;
		}

		[HttpGet]
		public IActionResult GetPostyTypes()
		{
			List<string> postTyleList = new List<string>();
			projectContext.PostTypes.ToList().ForEach(x => 
				postTyleList.Add(x.Type));

			return Ok(postTyleList);
		}
	}
}
