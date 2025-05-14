using Business_Logic.Core;
using Business_Logic.Interfaces;
using Domain.Enums;
using Domain.User;
using Domain.User.Reg;
using System;

namespace Business_Logic.BL_Struct
{
    public class RegBL : UserApi, IReg
    {
        public UserRegDataResp UserRegLogic(RegDataActionDTO uRegData)
        {
            return UserRegLogicAction(uRegData);
        }
    }
}