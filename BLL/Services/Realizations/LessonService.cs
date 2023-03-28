using AutoMapper;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
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

        public async Task<LessonResponse> getLessonById(int id)
        {
            var item = await repository.GetById(id);
            return mapper.Map<LessonResponse>(item);
        }
    }
}
