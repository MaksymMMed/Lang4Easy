using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Request
{
    public class CheckTranslateRequest
    {
        public int userId { get; set; }
        public int exerciseId { get; set; }
        public string? translatedText { get; set; }
    }
}
