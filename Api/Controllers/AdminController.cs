using Api.Models;
using Api.Repostories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repository;
        public AdminController(IAdminRepository repository)
        {
            _repository = repository;
        }

        // GET api/admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            return Ok(await _repository.GetAllAdminsAsync());
        }

        //GET api/admins/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            return Ok(await _repository.GetAdminByIdAsync(id));
        }

        //POST api/admins
        [HttpPost]
        public async Task<ActionResult<Admin>> CreateAdmin(Admin admin)
        {
            await _repository.AddAdminAsync(admin);
            return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id }, admin);
        }

        //PUT api/admins/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdmin(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingAdmin = await _repository.GetAdminByIdAsync(id);
            if (existingAdmin == null)
            {
                return NotFound();
            }

            await _repository.UpdateAdminAsync(admin);
            return NoContent();
        }

        //DELETE api/admins/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            await _repository.DeleteAdminAsync(id);
            return NoContent();
        }

    }
}