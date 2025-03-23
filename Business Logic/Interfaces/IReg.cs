using Business_Logic.Core;
using SkillSwaps.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
    public interface IReg
    {
        string UserRegLogic(UserRegData uRegData);
    }
}
