using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Admin> _userManager;
        public AuthController(UserManager<Admin> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] AdminRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var admin = new Admin
            {
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber

            };
            var result = await _userManager.CreateAsync(admin, model.Password);
            if (result.Succeeded)
            {
                return Ok(new { Message = "Admin registered successfully" });
            }
            return BadRequest(result.Errors);
        }
    }
}