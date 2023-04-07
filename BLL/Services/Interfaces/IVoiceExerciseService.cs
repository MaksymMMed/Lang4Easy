using BLL.DTO.Request;
using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IVoiceExerciseService
    {
        Task<VoiceExerciseResponse> GetVoiceExerciseById(int id);
        Task UpdateVoiceExercise(VoiceExerciseRequest request);
        Task AddVoiceExercise(VoiceExerciseRequest request);
        Task DeleteVoiceExercise(int id);
        Task SayText(VoiceExerciseRequest request);
        Task CheckText(VoiceExerciseRequest request);
    }
}
