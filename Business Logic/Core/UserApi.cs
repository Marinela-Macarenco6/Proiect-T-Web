using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

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

        public List<ArticleDataMain> GetAllArticleForAction()
        {
            return new List<ArticleDataMain>();
        }

    }
}
