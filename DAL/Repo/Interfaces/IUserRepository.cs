using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo.Interfaces
{
    public interface IUsesRepository:IRepository<User>
    {
        Task<User> GetUser(string login,string password);
    }
}
