using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Back.Interface.IBaseModelData;
using Entity_Back.Models.SecurityModels;

namespace Data_Back.Interface.IDataModels.Security
{
    public interface IUserData:IBaseModelData<User>

    {
        public Task<Person> SavePerson(Person person);
        public Task<User?> validarCredenciales(string email, string password);


        public Task<User> GetUserDetailAsync(int id);


        Task<string?> RequestPasswordResetAsync(string email);

        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);


    }
}
