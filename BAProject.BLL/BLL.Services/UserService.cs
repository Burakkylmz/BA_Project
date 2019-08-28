using BAProject.DAL.DAL.Context;
using BAProject.DAL.DAL.Repositories.Concrete;
using BAProject.Model.Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAProject.BLL.Services
{
    public class UserService : EFRepository<AppUser>
    {
        public UserService(BAProjeContext dbContext):base(dbContext)
        {

        }

        public string GenerateNewPassword(int length = 15)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}