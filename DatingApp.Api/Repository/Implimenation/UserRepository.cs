using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MyDatingapp.Api.Model;

namespace DatingApp.Api.Repository.Implimenation
{
    public class UserRepository : IUserRepository
    {
        private DatingAppContext _context;
        public UserRepository(DatingAppContext context)
        {
            _context = context;
        }
        public async Task<Tuser> AddUser(Tuser user)
        {
            _context.Tuser.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Tuser.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Tuser.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Tuser> GetTuser(int id)
        {
            var user = await _context.Tuser.Where(x => x.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<IList<Tuser>> GetUsers()
        {
            var user = await _context.Tuser.Include(x=>x.TuserPhoto).ToListAsync();
            return user;
        }
    }
}