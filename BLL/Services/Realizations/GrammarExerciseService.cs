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
    public class GrammarExerciseService : IGrammarExerciseService
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public GrammarExerciseService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public async Task AddGrammarExercise(GrammarExerciseRequest request)
        {
            var item = mapper.Map<GrammarExercise>(request);
            
            await unit.grammarExerciseRepository.Insert(item);

            var users = await unit.UserRepository.GetAll();

            var exercise = await unit.grammarExerciseRepository.FindByData(request.Name!,
                request.LessonId!, request.Question!, request.Answer!);
            foreach (var user in users)
            {
                CompleteStatus status = new();
                status.UserId = user.Id;
                status.ExerciseId = exercise.Id;
                status.Status = false;
                await unit.completeStatusRepository.Insert(status);
            }
        }

        public async Task<bool> CheckGrammar(CheckGrammarRequest checkGrammar)
        {
            var exercise = await unit.grammarExerciseRepository.GetById(checkGrammar.exerciseId);

            if (exercise.Answer == checkGrammar.Verb!.Trim())
            {
                var item = await unit.completeStatusRepository.GetComplete(checkGrammar.userId, exercise.Id);
                item.Status = true;
                await unit.completeStatusRepository.Update(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DeleteGrammarExercise(int id)
        {
            await unit.grammarExerciseRepository.Delete(id);

        }

        public async Task<GrammarExerciseResponse> GetGrammarExerciseById(int id)
        {
            var item = await unit.grammarExerciseRepository.GetById(id);
            return mapper.Map<GrammarExerciseResponse>(item);
        }

        public async Task UpdateGrammarExercise(GrammarExerciseRequest request)
        {
            var item = mapper.Map<GrammarExercise>(request);
            await unit.grammarExerciseRepository.Update(item);
        }
    }
}
