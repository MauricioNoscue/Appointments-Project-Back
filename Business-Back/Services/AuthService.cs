using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Implements.ModelDataImplement.Security;
using Data_Back.Interface.IDataModels.Security;
using Entity_Back.Models.SecurityModels;

namespace Business_Back.Services
{
    public class AuthService
    {

        private readonly IUserData _userData;

        public AuthService(IUserData data)
        {
            _userData = data;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _userData.validarCredenciales(email, password);
            if (user == null) return null;
            return user;
        }

    }
}
