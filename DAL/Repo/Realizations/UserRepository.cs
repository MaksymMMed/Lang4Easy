using DAL.Entities;
using DAL.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Realizations
{
    public class UserRepository : GenericRepository<User>, IUsesRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public override async Task<User> GetById(int id)
        {
                var user = await table.Where(x => x.Id == id).FirstOrDefaultAsync();
                return user ?? throw new ArgumentException("User not found");
        }

        public override async Task Insert(User user)
        {
            var entity = await table.Where(x=>x.Email == user.Email).FirstAsync();
            if (entity == null)
            {
                await table.AddAsync(user);
            }
            else
            {
                throw new ArgumentException("User with this email already exists");
            }
        }

        public async Task<User> GetUser(string email, string password)
        {
            var user = await table.Where(x => x.Email == email.Trim() && x.Password == password.Trim()).FirstOrDefaultAsync();
            return user ?? throw new ArgumentException("Wrong email or password");
        }
    }
}
