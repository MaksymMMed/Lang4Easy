using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Realizations
{
    public class TokenService : ITokenService
    {
        private string? _token;

        public void SetToken(string token)
        {
            _token = token;
        }

        public string GetToken()
        {
            return _token!;
        }

        public void DeleteToken()
        {
            _token = "";
        }
    }
}
