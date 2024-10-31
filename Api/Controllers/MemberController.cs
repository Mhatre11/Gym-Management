using Api.Models;
using Api.Repostories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _repository;


        public MemberController(IMemberRepository repository)
        {
            _repository = repository;
        }

        // Get api/members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetMembers()
        {
            return Ok(await _repository.GetAllMembersAsync());
        }

        // Get api/members/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMember(int id)
        {
            return Ok(await _repository.GetMemberByIdAsync(id));
        }

        // POST api/members
        [HttpPost]
        public async Task<ActionResult<Members>> CreateMember(Members member)
        {
            await _repository.AddMemberAsync(member);
            return CreatedAtAction(nameof(GetMember), new { id = member.ID }, member);
        }

        // PUT api/members/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMember(int id, Members member)
        {
            if (id != member.ID)
            {
                return BadRequest();
            }
            await _repository.UpdateMemberAsync(member);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMember(int id)
        {
            await _repository.DeleteMemberAsync(id);
            return NoContent();
        }
    }
}