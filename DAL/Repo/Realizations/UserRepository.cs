using DAL.Entities;
using DAL.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography;


namespace DAL.Repo.Realizations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            var users = await table.ToListAsync();
            return users;
        }

        public override async Task<User> GetById(int id)
        {
                var user = await table.Where(x => x.Id == id)
                .Include(x=>x.CompletedExercise!)
                .ThenInclude(x=> x.Exercise)
                .FirstOrDefaultAsync();
                return user ?? throw new ArgumentException("User not found");
        }

        public override async Task Insert(User user)
        {
            var entity = await table.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (entity == null)
            {
                user.Role = "user";

                using var sha256 = SHA256.Create();
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password!));
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "");

                user.Password = hashString;

                await table.AddAsync(user);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("User with this email already exists");
            }
        }

        public async Task<User> GetUser(string email, string password)
        {
            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password!));
            string hashString = BitConverter.ToString(hashBytes).Replace("-", "");

            var user = await table.Where(x => x.Email!.Trim() == email!.Trim() && x.Password!.Trim() == hashString!.Trim())
                .Include(x=>x.CompletedExercise!)
                .ThenInclude(x=>x.Exercise)
                .FirstOrDefaultAsync();

            
            if (user == null)
            {
                throw new ArgumentException("Wrong email or password");
            }
            else
            {
                return user;
            }
        }
    }
}
