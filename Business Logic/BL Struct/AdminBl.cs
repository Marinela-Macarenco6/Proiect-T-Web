using Business_Logic.Core;
using Business_Logic.Interfaces;
using Domain.Admin;
using Domain.Article;
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

        public bool EditUserAcc(UserDataMain userData)
        {
            return EditUserAccAction(userData);
        }

        public List<UserDataMain> SearchUser(string userData)
        {
            return SearchUserAction(userData);
        }

        public List<ArticleDataMain> GetPendingCourses()
        {
            return GetPendingCoursesAction();
        }

        public bool RejectCoursePublication(ArticleDataMain articleData)
        {
            return RejectCoursePublicationAction(articleData);
        }


    }
}
