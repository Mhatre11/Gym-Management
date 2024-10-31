using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repostories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Members>> GetAllMembersAsync();
        Task<Members> GetMemberByIdAsync(int id);
        Task AddMemberAsync(Members member);
        Task UpdateMemberAsync(Members member);
        Task DeleteMemberAsync(int id);
    }

    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _context;
        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Members>> GetAllMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Members> GetMemberByIdAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                throw new Exception("Member not found");
            }
            return member!;
        }

        public async Task AddMemberAsync(Members member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMemberAsync(Members member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
            await _context.SaveChangesAsync();
        }

    }
}