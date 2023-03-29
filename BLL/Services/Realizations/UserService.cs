using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Realizations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddUser(UserRequest request)
        {
            var item = mapper.Map<User>(request);
            await repository.Insert(item);
        }

        public async Task DeleteUser(int id)
        {
            await repository.Delete(id);
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var item = await repository.GetById(id);
            return mapper.Map<UserResponse>(item);
        }

        public async Task<UserResponse> GetUser(string email, string password)
        {
            var item = await repository.GetUser(email, password);
            return mapper.Map<UserResponse>(item);
        }

        public async Task UpdateUser(UserRequest request)
        {
            var item = mapper.Map<User>(request);
            await repository.Update(item);
        }
    }
}
