using Domain.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
    public interface IAdmin
    {
        List<UserDataMain> GetAllUser();
        List<UserDataMain> GetAllOnlineUser();
        bool BannUserAcc(UserDataMain userData);

    }
}
