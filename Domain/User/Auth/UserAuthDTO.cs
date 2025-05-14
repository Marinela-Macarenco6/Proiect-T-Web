using System;

namespace Domain.User
{
    public class UserAuthDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserIp { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
