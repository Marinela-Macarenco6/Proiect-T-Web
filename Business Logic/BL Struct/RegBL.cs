using Business_Logic.Core;
using Business_Logic.Interfaces;
using Domain.Enums;
using Domain.User;
using Domain.User.EditAcc;
using Domain.User.Reg;
using Domain.User.UserActionResp;
using System;
using System.Web;

namespace Business_Logic.BL_Struct
{
    public class RegBL : UserApi, IReg
    {
        public UserResp GetUserByCookie(string sessionKey)
        {
            return GetUserByCookieAction(sessionKey) ;
        }

        public UserRegDataResp UserRegLogic(RegDataActionDTO uRegData)
        {
            return UserRegLogicAction(uRegData);
        }

        public bool UserChangePassword(ChangePasswordData changePswdData)
        {
            return UserChangePasswordAction(changePswdData);
        }

        public bool UserChangeUsername(ChangeUsernameData changeUsernameData)
        {
            return UserChangeUsernameAction(changeUsernameData);
        }
    }
}