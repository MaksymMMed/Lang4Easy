using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Realizations
{
    public class TranslateExerciseService : ITranslateExerciseService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public TranslateExerciseService(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public async Task AddTranslateExercise(TranslateExerciseRequest request)
        {
            var item = mapper.Map<TranslateExercise>(request);
            await unit.translateExerciseRepository.Insert(item);
        }

        public async Task<bool> CheckTranslate(CheckTranslateRequest checkTranslate)
        {
            var exercise = await unit.translateExerciseRepository.GetById(checkTranslate.exerciseId);

            if (exercise.Answer == checkTranslate.translatedText!.Trim())
            {
                var item = await unit.completeStatusRepository.GetComplete(checkTranslate.userId, exercise.Id);
                item.Status = true;
                await unit.completeStatusRepository.Update(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DeleteTranslateExercise(int id)
        {
            await unit.translateExerciseRepository.Delete(id);
        }

        public async Task<TranslateExerciseResponse> GetTranslateExerciseById(int id)
        {
            var item = await unit.translateExerciseRepository.GetById(id);
            return mapper.Map<TranslateExerciseResponse>(item);
        }

        public async Task UpdateTranslateExercise(TranslateExerciseRequest request)
        {
            var item = mapper.Map<TranslateExercise>(request);
            await unit.translateExerciseRepository.Update(item);
        }
    }
}
