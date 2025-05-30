﻿using Domain.Admin;
using Domain.Article;
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
        bool EditUserAcc(UserDataMain userData);
       // List<UserDataMain> GetAllBannedUser();
        List<UserDataMain> SearchUser(string userData);
        List<ArticleDataMain> GetPendingCourses();
        bool RejectCoursePublication(ArticleDataMain articleData);

    }
}
