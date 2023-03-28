using BLL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ILessonService
    {
        Task<LessonResponse> getLessonById(int id);
    }
}
