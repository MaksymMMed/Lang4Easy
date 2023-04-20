using BLL.DTO.Request;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ITranslateExerciseService
    {
        Task<TranslateExerciseResponse> GetTranslateExerciseById(int id);
        Task UpdateTranslateExercise(TranslateExerciseRequest request);
        Task AddTranslateExercise(TranslateExerciseRequest request);
        Task DeleteTranslateExercise(int id);
        Task<bool> CheckTranslate(CheckTranslateRequest checkTranslate);
    }
}
