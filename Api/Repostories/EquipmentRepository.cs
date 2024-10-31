using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repostories
{

    public interface IEquipmentRepository
    {
        public Task<IEnumerable<Equipments>> GetAllEquipmentsAsync();
        public Task<Equipments> GetEquipmentByIdAsync(int id);
        public Task AddEquipmentAsync(Equipments equipment);
        public Task UpdateEquipmentAsync(Equipments equipment);
        public Task DeleteEquipmentAsync(int id);
    }

    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AppDbContext _context;

        public EquipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipments>> GetAllEquipmentsAsync()
        {
            return await _context.Equipments.ToListAsync();
        }
        public async Task<Equipments> GetEquipmentByIdAsync(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id) ?? throw new Exception("Equipment not found");
            return equipment!;
        }

        public async Task AddEquipmentAsync(Equipments equipment)
        {
            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEquipmentAsync(Equipments equipment)
        {
            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
            }
            await _context.SaveChangesAsync();
        }
    }
}