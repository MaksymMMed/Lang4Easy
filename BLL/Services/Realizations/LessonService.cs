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
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository repository;
        private readonly IMapper mapper;

        public LessonService(ILessonRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddLesson(LessonRequest request)
        {
            var item = mapper.Map<Lesson>(request);
            await repository.Insert(item);
        }

        public async Task DeleteLesson(int id)
        {
            await repository.Delete(id);
        }

        public async Task<LessonResponse> GetLessonById(int id)
        {
            var item = await repository.GetById(id);
            return mapper.Map<LessonResponse>(item);
        }

        public async Task<IEnumerable<LessonResponse>> GetLessons()
        {
            var items = await repository.GetAll();
            return mapper.Map<IEnumerable<Lesson>,IEnumerable<LessonResponse>>(items); 
        }

        public async Task UpdateLesson(LessonRequest request)
        {
            var item = mapper.Map<Lesson>(request);
            await repository.Update(item);
        }
    }
}
