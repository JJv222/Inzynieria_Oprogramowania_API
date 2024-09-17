using Inzynieria_oprogramowania_API.Data_Models;
using Inzynieria_oprogramowania_API.Database;
using Inzynieria_oprogramowania_API.DTO_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Inzynieria_oprogramowania_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly ProjectContext projectContext;
		public UsersController(ProjectContext projectContext)
		{
			this.projectContext = projectContext;
		}

		[HttpPost("Register")]
		public IActionResult Register([FromBody] UserRegisterDTO newUser)
		{
			if (projectContext.Users.FirstOrDefault(x => x.Name == newUser.Name) != null || !ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if(newUser.Password != newUser.PasswordRepeat)
			{
				return BadRequest(ModelState);
			}

			projectContext.Users.Add(new User { 
				Name = newUser.Name, 
				Password = newUser.Password,
				Role = "User"
			});
			projectContext.SaveChanges();
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpPost("Login")]
		public IActionResult Login([FromBody] UserLoginDTO user)
		{
			var userFromDb = projectContext.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
			if (userFromDb == null)
			{
				return Unauthorized();
			}
			return Ok();
		}

	}
}
