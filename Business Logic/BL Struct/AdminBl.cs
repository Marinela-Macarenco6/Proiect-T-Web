using Business_Logic.Core;
using Business_Logic.Interfaces;
using Domain.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.BL_Struct
{
    public class AdminBl : UserApi, IAdmin
    {
        public List<UserDataMain> GetAllUser()
        {
            return GetAllUserAction();
        }

        public List<UserDataMain> GetAllOnlineUser()
        {
            return GetAllOnlineUserAction();
        }

        public bool BannUserAcc(UserDataMain userData)
        {
            return BanUserAccAction(userData);
        }


    }
}
