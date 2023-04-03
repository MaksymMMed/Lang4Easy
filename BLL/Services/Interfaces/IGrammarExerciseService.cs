using BLL.DTO.Request;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IGrammarExerciseService
    {
        Task<GrammarExerciseResponse> GetGrammarExerciseById(int id);
        Task UpdateGrammarExercise(GrammarExerciseRequest request);
        Task AddGrammarExercise(GrammarExerciseRequest request);
        Task DeleteGrammarExercise(int id);
        Task CheckTranslate(GrammarExerciseRequest request);
    }
}
