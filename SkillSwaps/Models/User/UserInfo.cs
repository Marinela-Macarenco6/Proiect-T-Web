using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillSwaps.Models.User
{
	public class UserInfo
	{
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? RequestTime { get; set; }
        public string UserRole { get; set; }

    }
}