using Domain.User;
using SkillSwaps.Models.User;
using System;

namespace SkillSwaps.Controllers
{
    internal class AuthDataAction : AuthData
    {
        public new string Password { get; set; }
        public new string UserName { get; set; }
        public new DateTime RequestTime { get; set; }
    }
}