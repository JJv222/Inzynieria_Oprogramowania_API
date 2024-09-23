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
			if (projectContext.Users.FirstOrDefault(x => x.Username == newUser.Username) != null || 
				projectContext.Users.FirstOrDefault(x => x.Email == newUser.Email) != null || 
				projectContext.Users.FirstOrDefault(x=> x.Phone == newUser.PhoneNumber) != null ||
				!ModelState.IsValid)
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
				Username = newUser.Username,
				Phone = newUser.PhoneNumber,
				Surname = newUser.Surname,
				Role = "User",
				Email = newUser.Email,
				Reputation = 10
			});
			projectContext.SaveChanges();

			projectContext.Options.Add(new Option
			{
				Email = "true",
				LocationBased = "true",
				Sms = "true",
				UserId = projectContext.Users.FirstOrDefault(x => x.Username == newUser.Username).ID
			});
			projectContext.SaveChanges();

			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpPost("Login")]
		public IActionResult Login([FromBody] UserLoginDTO user)
		{
			if (projectContext.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password) == null)
			{
				return Unauthorized();
			}
			return Ok();
		}

		[HttpGet("GetUserProfile")]
		public IActionResult GetUserProfile([FromHeader] string username)
		{
			var user = projectContext.Users.FirstOrDefault(x => x.Username == username);
			if (user == null)
			{
				return NotFound();
			}
			var option = projectContext.Options.FirstOrDefault(x => x.UserId == user.ID);
			if (option == null)
			{
				return NotFound();
			}
			return Ok(new UserProfileDTO
			{
				Email = user.Email,
				Name = user.Name,
				PhoneNumber = user.Phone,
				Reputation = user.Reputation,
				Surname = user.Surname,
				Username = user.Username,

				LocationBased = option.LocationBased,
				EmailOption = option.Email,
				Sms = option.Sms
			});
		}

	}
}
