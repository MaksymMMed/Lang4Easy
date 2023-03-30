using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> GetUser(string email,string password);
    }
}
