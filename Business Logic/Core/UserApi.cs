using System;
using System.Linq;
using Domain.User;
using Business_Logic.DbDataContext.Seed;

namespace Business_Logic.Core
{
    public class UserApi
    {
        internal bool ValidateSessionIdAction(string id)
        {
            return true;
        }
        internal string AuthUserAction(UserAuthData data) 
        {
            if (data != null)
            {
                bool isUserNameValid = false;
                if (isUserNameValid)
                {

                    //Check if password is correct





                    //All ok!
                    var sessionKey = GenerateSessionKey(data.UserName, "utm2025");
                    return sessionKey;
                }
            }
            return string.Empty;
        }
        private  string GenerateSessionKey(string username, string noise)
        {
            string sKey = username + noise;
            return sKey;
        }



        //-----------------------REG----------------------------
        public string UserRegLogicAction(RegDataActionDTO data)
        {
            if (data == null
                || string.IsNullOrEmpty(data.UserName)
                || string.IsNullOrEmpty(data.Password)
                || string.IsNullOrEmpty(data.ConfirmPassword)
                || string.IsNullOrEmpty(data.FullName)
                || string.IsNullOrEmpty(data.Email))
            {
                return string.Empty;
            }

            // Verificăm dacă parolele se potrivesc
            if (data.Password != data.ConfirmPassword)
            {
                return string.Empty;
            }

            using (var db = new UserContext())
            {
                // Verificăm dacă username-ul sau email-ul există deja
                var existingUser = db.UserRegDatas.FirstOrDefault(u => u.UserName == data.UserName || u.Email == data.Email);
                if (existingUser != null)
                {
                    return string.Empty;
                }

                // Creăm noul utilizator
                var newUser = new UserRegData
                {
                    FullName = data.FullName,
                    UserName = data.UserName,
                    Email = data.Email,
                    Password = data.Password,
                    ConfirmPassword = data.ConfirmPassword,
                    RequestTime = DateTime.UtcNow
                };

                db.UserRegDatas.Add(newUser);
                db.SaveChanges();
            }

            var sessionKey = GenerateSessionKey(data.UserName, "utm2025");
            return sessionKey;
        }
    }
}
