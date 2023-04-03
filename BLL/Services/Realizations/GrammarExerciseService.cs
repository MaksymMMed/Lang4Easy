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
        private readonly IMapper mapper;

        public GrammarExerciseService(IGrammarExerciseRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddGrammarExercise(GrammarExerciseRequest request)
        {
            var item = mapper.Map<GrammarExercise>(request);
            await repository.Insert(item);
        }

        public Task CheckTranslate(GrammarExerciseRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGrammarExercise(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GrammarExerciseResponse> GetGrammarExerciseById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGrammarExercise(GrammarExerciseRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
