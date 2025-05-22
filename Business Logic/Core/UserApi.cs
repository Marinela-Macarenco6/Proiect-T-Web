using Business_Logic.DbDataContext.Seed;
using Domain.Admin;
using Domain.Enums;
using Domain.User;
using Domain.User.EditAcc;
using Domain.User.Reg;
using Domain.User.UserActionResp;
using Helpers.RegFlow;
using Helpers.Session;
using SkillSwaps.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business_Logic.Core
{
    public class UserApi
    {

        //----------------------- AUTH ----------------------------
        internal UserResp AuthUserAction(UserAuthDTO data)
        {
            UserRegData user;

            try
            {
                var passHashed = RegPassHelper.HashGen(data.Password);

                using (var db = new UserContext())
                {
                    user = db.UserRegDatas.FirstOrDefault(
                        u => u.UserName == data.UserName && u.Password == passHashed);
                }
            }
            catch (Exception ex)
            {
                return new UserResp()
                {
                    Status = false,
                    Error = ex.Message
                };
            }

            if (user == null)
            {
                return new UserResp()
                {
                    Status = false,
                    Error = "no user found"
                };
            }



            return new UserResp()
            {
                Status = true,
                Error = string.Empty,
                UserId = user.Id,
                UserName = user.UserName,
            };
        }
        internal UserCookieResp GeneratCookieByUserAction(int userId)
        {
            var cookieString = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(userId + "[0.0.0.0]" + "ISP: Super Fast Internet")
            };

            var dateTime = DateTime.Now;

            USessionDbTable session;

            using (var db = new SessionContext())
            {
                session = db.Session.FirstOrDefault(u => u.UserId == userId);

            }

            if (session != null)
            {
                //UPDATE TABLE

                session.Cookie = cookieString.Value;
                session.IsValidATime = dateTime.AddHours(3);

                using (var db = new SessionContext())
                {
                    db.Entry(session).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            else
            {
                //INSERT TABLE

                session = new USessionDbTable()
                {
                    UserId = userId,
                    Cookie = cookieString.Value,
                    IsValidATime = dateTime.AddHours(3)
                };

                using (var db = new SessionContext())
                {
                    db.Session.Add(session);
                    db.SaveChanges();
                }

            }


            return new UserCookieResp() { UserId = userId, Cookie = cookieString, ValidUntil = dateTime };
        }
        internal UserResp GetUserByCookieAction(string cookieKey)
        {
            USessionDbTable session;
            UserRegData user;

            using (var db = new SessionContext())
            {
                session = db.Session.FirstOrDefault(s => s.Cookie == cookieKey);

                if (session == null)
                    return new UserResp { Status = false, Error = "Sesiunea nu a fost gasita." };

                if (session.IsValidATime <= DateTime.Now)
                    return new UserResp { Status = false, Error = "Sesiunea a expirat." };

                // Reînnoiește expirarea sesiunii (+30 minute)
                session.IsValidATime = DateTime.Now.AddMinutes(30);
                db.Entry(session).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            using (var db = new UserContext())
            {
                user = db.UserRegDatas.FirstOrDefault(u => u.Id == session.UserId);
            }

            if (user == null)
                return new UserResp { Status = false, Error = "Utilizatorul nu mai exista." };

            return new UserResp
            {
                Status = true,
                UserId = user.Id,
                UserName = user.UserName,
                Role = user.userRole
            };
        }


        //----------------------- REG ----------------------------
        public UserRegDataResp UserRegLogicAction(RegDataActionDTO data)
        {
            UserRegData user;
            try
            {
                using (var db = new UserContext())
                {
                    user = db.UserRegDatas
                        .FirstOrDefault(u => u.UserName == data.UserName || u.Email == data.Email);
                }
            }
            catch (Exception ex)
            {
                return new UserRegDataResp
                {
                    Status = false,
                    Error = "Eroare: " + ex.Message
                };
            }

            if (user != null)
            {
                return new UserRegDataResp
                {
                    Status = false,
                    Error = "Utilizatorul există deja cu acest username sau email."
                };
            }

            var passHashed = RegPassHelper.HashGen(data.Password);

            user = new UserRegData
            {
                FullName = data.FullName,
                UserName = data.UserName,
                Email = data.Email,
                Password = passHashed,
                RequestTime = DateTime.UtcNow.ToLocalTime(),
                userRole = 0
    };

            using (var db = new UserContext())
            {
                db.UserRegDatas.Add(user);
                db.SaveChanges();
            }

            return new UserRegDataResp
            {
                Status = true,
                Error = string.Empty,
                UserId = user.Id
            };
        }


        //----------------------- LOGOUT ----------------------------
        internal bool LogoutUserAction(string cookieKey)
        {
            USessionDbTable session;

            using (var db = new SessionContext())
            {
                 session = db.Session.FirstOrDefault(s => s.Cookie == cookieKey);

                if (session != null)
                {
                    db.Session.Remove(session);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        //----------------------- EDIT ACCOUNT ----------------------------
        public UserResp UserChangePasswordAction(ChangePasswordData changePswdData)
        {
            UserRegData user;

            var userResp = GetUserByCookieAction(changePswdData.UserId);

            if (!userResp.Status)
            {
                return new UserResp
                {
                    Status = false,
                    Error = userResp.Error
                };
            }

            var oldHashed = RegPassHelper.HashGen(changePswdData.OldPassword);

            using (var userDb = new UserContext())
            {
                 user = userDb.UserRegDatas
                    .FirstOrDefault(u => u.Id == userResp.UserId);

                if (user == null)
                {
                    return new UserResp
                    {
                        Status = false,
                        Error = "Utilizatorul nu a fost găsit."
                    };
                }

                if (user.Password != oldHashed)
                {
                    return new UserResp
                    {
                        Status = false,
                        Error = "Parola introdusă este incorectă."
                    };
                }

                user.Password = RegPassHelper.HashGen(changePswdData.NewPassword);

                userDb.Entry(user).State = System.Data.Entity.EntityState.Modified;
                userDb.SaveChanges();

                return new UserResp
                {
                    Status = true,
                    UserId = user.Id,
                    UserName = user.UserName,
                    Role = user.userRole
                };
            }
        }
        public UserResp UserChangeUsernameAction(ChangeUsernameData changeUsernameData)
        {
            UserRegData user;

            var userResp = GetUserByCookieAction(changeUsernameData.SessionKey);

            if (!userResp.Status)
            {
                return new UserResp
                {
                    Status = false,
                    Error = userResp.Error
                };
            }

            var passHashed = RegPassHelper.HashGen(changeUsernameData.Password);

            using (var userDb = new UserContext())
            {
                // Verificăm dacă există un user cu acel ID și cu parola corectă
                 user = userDb.UserRegDatas
                    .FirstOrDefault(u => u.Id == userResp.UserId && u.Password == passHashed);

                if (user == null)
                {
                    return new UserResp
                    {
                        Status = false,
                        Error = "Parola introdusă este incorectă."
                    };
                }

                var existingUser = userDb.UserRegDatas
                    .FirstOrDefault(u => u.UserName.ToLower() == changeUsernameData.NewUsername.ToLower()
                                      && u.Id != userResp.UserId);

                if (existingUser != null)
                {
                    return new UserResp
                    {
                        Status = false,
                        Error = "Username indisponibil."
                    };
                }

                // Dacă totul e în regulă, actualizăm numele de utilizator
                user.UserName = changeUsernameData.NewUsername;

                userDb.Entry(user).State = System.Data.Entity.EntityState.Modified;
                userDb.SaveChanges();

                return new UserResp
                {
                    Status = true,
                    UserId = user.Id,
                    UserName = user.UserName,
                    Role = user.userRole
                };
            }
        }
        public UserResp UserChangeEmailAction(ChangeEmailData changeEmailData)
        {
            UserRegData user;

            var UserResp = GetUserByCookieAction(changeEmailData.SessionKey);

            if (!UserResp.Status)
            {
                return new UserResp
                {
                    Status = false,
                    Error = UserResp.Error
                };
            }

            var passHashed = RegPassHelper.HashGen(changeEmailData.Password);

            using (var userDb = new UserContext())
            {
                user = userDb.UserRegDatas
                    .FirstOrDefault(u => u.Id == UserResp.UserId && u.Password == passHashed);

                if (user == null)
                {
                    return new UserResp
                    {
                        Status = false,
                        Error = "Parola introdusă este incorectă."
                    };
                }

                // Verificăm dacă noul email este identic cu cel deja salvat
                if (user.Email.ToLower() == changeEmailData.NewEmail.ToLower())
                {
                    return new UserResp
                    {
                        Status = false,
                        Error = "Noul email este identic cu cel actual."
                    };
                }

                // Verificăm dacă emailul nou există la alt utilizator
                var existingGmail = userDb.UserRegDatas
                    .FirstOrDefault(u => u.Email.ToLower() == changeEmailData.NewEmail.ToLower()
                                      && u.Id != UserResp.UserId);

                if (existingGmail != null)
                {
                    return new UserResp
                    {
                        Status = false,
                        Error = "Adresă Email indisponibilă."
                    };
                }

                user.Email = changeEmailData.NewEmail;
                userDb.Entry(user).State = System.Data.Entity.EntityState.Modified;
                userDb.SaveChanges();

                return new UserResp
                {
                    Status = true,
                    UserId = user.Id,
                    UserName = user.UserName,
                    Role = user.userRole
                };
            }
        }


        //----------------------- ADMIN ----------------------------
        public List<UserDataMain> GetAllUserAction()
        {
            using (var db = new UserContext())
            {
                return db.UserRegDatas
                    .Select(u => new UserDataMain
                    {
                        UserId = u.Id,
                        FullName = u.FullName,
                        UserName = u.UserName,
                        Email = u.Email,
                        RequestTime = u.RequestTime,
                        UserRole = u.userRole
                    })
                    .ToList();
            }
        }
        public List<UserDataMain> GetAllOnlineUserAction()
        {
            using (var sessionDb = new SessionContext())
            using (var userDb = new UserContext())
            {
                var activeUserIds = sessionDb.Session
                    .Where(s => s.IsValidATime > DateTime.Now)
                    .Select(s => s.UserId)
                    .Distinct()
                    .ToList();

                return userDb.UserRegDatas
                    .Where(u => activeUserIds.Contains(u.Id))
                    .Select(u => new UserDataMain
                    {
                        UserId = u.Id,
                        FullName = u.FullName,
                        UserName = u.UserName,
                        Email = u.Email,
                        RequestTime = u.RequestTime,
                        UserRole = u.userRole
                    })
                    .ToList();
            }
        }
        public bool BanUserAccAction(UserDataMain data)
        {
            using (var db = new UserContext())
            {
                var user = db.UserRegDatas.FirstOrDefault(u => u.Id == data.UserId);

                if (user != null)
                {
                    if (user.userRole == EURole.IsBanned)
                    {
                        // Utilizatorul este deja banat
                        return false;
                    }

                    user.userRole = EURole.IsBanned;
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }







    }
}



