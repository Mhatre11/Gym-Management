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
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentRepository _repository;

        public EquipmentController(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipments>>> GetEquipments()
        {
            return Ok(await _repository.GetAllEquipmentsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEquipmentById(int id)
        {
            return Ok(await _repository.GetEquipmentByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddEquipment(Equipments equipment)
        {
            await _repository.AddEquipmentAsync(equipment);
            return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.ID }, equipment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEquipment(int id, Equipments equipment)
        {
            if (id != equipment.ID)
            {
                return BadRequest();
            }
            await _repository.UpdateEquipmentAsync(equipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEquipment(int id)
        {
            await _repository.DeleteEquipmentAsync(id);
            return NoContent();
        }
    }
}