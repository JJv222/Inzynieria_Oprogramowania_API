using Inzynieria_oprogramowania_API.Data_Models;
using Inzynieria_oprogramowania_API.Database;
using Inzynieria_oprogramowania_API.DTO_Models;
using Microsoft.AspNetCore.Mvc;

namespace Inzynieria_oprogramowania_API.Controllers
{
	[Route("api/[controller]")]
	public class OptionsController : ControllerBase
	{
		private readonly ProjectContext projectContext;
		public OptionsController(ProjectContext projectContext)
		{
			this.projectContext = projectContext;
		}

		[HttpGet]
		public IActionResult GetOptions([FromHeader] string userName)
		{
			if(projectContext.Users.FirstOrDefault(x => x.Username == userName) == null)
			{
				return BadRequest();
			}
			var userId = projectContext.Users.FirstOrDefault(x => x.Username == userName).ID;
			OptionDTO option = new OptionDTO();
			Option orginalOption = projectContext.Options.FirstOrDefault(x => x.UserId == userId);
			
			option.EmailOption = orginalOption.LocationBased;
			option.Sms = orginalOption.Sms;
			option.LocationBased = orginalOption.LocationBased;

			return Ok(option);
		}

		[HttpPost]
		public IActionResult UpdateOptions([FromHeader] string userName, [FromBody] OptionDTO request)
		{
			var user = projectContext.Users.FirstOrDefault(x => x.Username == userName);
			if (user == null)
			{
				return BadRequest("User not found.");
			}

			var userOptions = projectContext.Options.FirstOrDefault(x => x.UserId == user.ID);
			if (userOptions == null)
			{
				userOptions = new Option
				{
					UserId = user.ID,
					Sms = request.Sms,
					Email = request.EmailOption,
					LocationBased = request.LocationBased
				};
				projectContext.Options.Add(userOptions);
			}
			else
			{
				userOptions.Sms = request.Sms;
				userOptions.Email = request.EmailOption;
				userOptions.LocationBased = request.LocationBased;
			}
			projectContext.SaveChanges();
			return Ok("Options updated successfully.");
		}

	}
}
