using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public List<CompleteStatus>? CompletedExercise { get; set; }
        public string? Role { get; set; }

        public string Token { get; set; }
    }
}
