using BLL.DTO.Request;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> GetUserById(int id);
        Task UpdateUser(UserRequest request);
        Task AddUser(UserRequest request);
        Task DeleteUser(int id);
        Task<UserResponse> GetUser(string email,string password);
    }
}
