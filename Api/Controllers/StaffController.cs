using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Repostories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _repository;

        public StaffController(IStaffRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return Ok(await _repository.GetAllStaffsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStaffById(int id)
        {
            return Ok(await _repository.GetStaffByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddStaff(Staff staff)
        {
            await _repository.AddStaffAsync(staff);
            return CreatedAtAction(nameof(GetStaffById), new { id = staff.ID }, staff);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStaff(int id, Staff staff)
        {
            await _repository.UpdateStaffAsync(staff);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            await _repository.GetStaffByIdAsync(id);
            return NoContent();
        }
    }
}