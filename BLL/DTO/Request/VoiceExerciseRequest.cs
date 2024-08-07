﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Request
{
    public class VoiceExerciseRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Answer { get; set; }
        public int LessonId { get; set; }
        public string? TextToSay { get; set; }
        public int Type { get; set; }
        public List<string>? Variables { get; set; }
    }
}
