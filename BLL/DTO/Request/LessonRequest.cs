using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Request
{
    public class LessonRequest
    {
        public string? LessonName { get; set; }
        public string? LessonDescription { get; set; }
    }
}
