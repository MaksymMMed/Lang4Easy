using BLL.DTO.Request;
using BLL.DTO.Response;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ILessonService
    {
        Task<LessonResponse> GetLessonById(int id);
        Task UpdateLesson(LessonRequest request);
        Task AddLesson(LessonRequest request);
        Task DeleteLesson(int id);
        Task<IEnumerable<LessonResponse>> GetLessons();
    }
}
