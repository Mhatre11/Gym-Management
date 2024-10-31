using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Repostories
{
    public interface IStaffRepository
    {
        public Task<IEnumerable<Staff>> GetAllStaffsAsync();
        public Task<Staff> GetStaffByIdAsync(int id);
        public Task AddStaffAsync(Staff staff);
        public Task UpdateStaffAsync(Staff staff);
        public Task DeleteStaffAsync(int id);
    }

    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _context;
        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Staff>> GetAllStaffsAsync()
        {
            return await _context.Staff.ToListAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            var staff = await _context.Staff.FindAsync(id) ?? throw new Exception("Staff not found");
            return staff!;
        }

        public async Task AddStaffAsync(Staff staff)
        {
            await _context.Staff.AddAsync(staff);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            _context.Staff.Update(staff);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStaffAsync(int id)
        {
            var staff = await _context.Staff.FindAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
            }
            await _context.SaveChangesAsync();
        }

    }
}