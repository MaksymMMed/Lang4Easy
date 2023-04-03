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
    public class GrammarExerciseService : IGrammarExerciseService
    {
        private readonly IGrammarExerciseRepository repository;
        private readonly ICompleteStatusRepository statusRepository;
        private readonly IMapper mapper;

        public GrammarExerciseService(IGrammarExerciseRepository repository, ICompleteStatusRepository statusRepository, IMapper mapper)
        {
            this.repository = repository;
            this.statusRepository = statusRepository;
            this.mapper = mapper;
        }

        public async Task AddGrammarExercise(GrammarExerciseRequest request)
        {
            var item = mapper.Map<GrammarExercise>(request);
            await repository.Insert(item);
        }

        public async Task CheckTranslate(GrammarExerciseRequest request, string translatedText,int userId)
        {
            if (request.Answer == translatedText.Trim())
            {
                var item = await statusRepository.GetComplete(userId, request.Id);
                item.Status = true;
                await statusRepository.Update(item);
            }
        }

        public async Task DeleteGrammarExercise(int id)
        {
            await repository.Delete(id);
        }

        public async Task<GrammarExerciseResponse> GetGrammarExerciseById(int id)
        {
            var item = await repository.GetById(id);
            return mapper.Map<GrammarExerciseResponse>(item);
        }

        public async Task UpdateGrammarExercise(GrammarExerciseRequest request)
        {
            var item = mapper.Map<GrammarExercise>(request);
            await repository.Update(item);
        }
    }
}
