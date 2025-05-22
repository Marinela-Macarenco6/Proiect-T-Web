using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Admin
{
    public class UserDataMain
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public  EURole UserRole { get; set; }
        public int UserId { get; set; }
        public DateTime? RequestTime { get; set; }
    }
}
