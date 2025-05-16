using Business_Logic.DbDataContext.Seed;
using Domain.User;
using Domain.User.Reg;
using Domain.User.UserActionResp;
using Helpers.RegFlow;
using Helpers.Session;
using SkillSwaps.Models.Session;
using System;
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
                UserId = 1,
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
                session = db.Session.FirstOrDefault(s => s.Cookie.Contains (cookieKey));
            }

            if (session != null)
            { 
                using (var db = new UserContext())
                {
                    user = db.UserRegDatas .FirstOrDefault(u => u.Id == session.UserId);
                }   

                if (user != null)
                {
                    return new UserResp
                    {
                        Status = true,
                        UserId = user.Id,
                        UserName = user.UserName,
                        Role = user.userRole,
                    };
                }
            }

            return new UserResp { Status = false };
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
    }
}


