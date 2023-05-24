using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repo.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Realizations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public async Task AddUser(UserRequest request)
        {
            var item = mapper.Map<User>(request);

            await unit.UserRepository.Insert(item);
            var user = await unit.UserRepository.GetUser(request.Email!, request.Password!);
            Console.WriteLine(user);

            List<Exercise> exercises1 = (await unit.grammarExerciseRepository.GetAll()).OfType<Exercise>().ToList();
            foreach (var exercise in exercises1)
            {
                CompleteStatus status = new()
                {
                    UserId = user.Id,
                    ExerciseId = exercise.Id
                };
                await unit.completeStatusRepository.Insert(status);
            }

            List<Exercise> exercises2 = (await unit.voiceExerciseRepository.GetAll()).OfType<Exercise>().ToList();
            foreach (var exercise in exercises2)
            {
                CompleteStatus status = new()
                {
                    UserId = user.Id,
                    ExerciseId = exercise.Id
                };
                await unit.completeStatusRepository.Insert(status);
            }

            List<Exercise> exercises3 = (await unit.translateExerciseRepository.GetAll()).OfType<Exercise>().ToList();
            foreach (var exercise in exercises3)
            {
                CompleteStatus status = new()
                {
                    UserId = user.Id,
                    ExerciseId = exercise.Id
                };
                await unit.completeStatusRepository.Insert(status);
            }
        }

        public async Task DeleteUser(int id)
        {
            await unit.UserRepository.Delete(id);
        }

        public async Task<UserResponse> GetUserById(int id)
        {
            var item = await unit.UserRepository.GetById(id);
            return mapper.Map<UserResponse>(item);
        }

        public async Task<UserResponse> GetUser(string email, string password)
        {
            var item = await unit.UserRepository.GetUser(email, password);
            return mapper.Map<UserResponse>(item);
        }

        public async Task UpdateUser(UserRequest request)
        {
            var item = mapper.Map<User>(request);
            await unit.UserRepository.Update(item);
        }
    }
}
