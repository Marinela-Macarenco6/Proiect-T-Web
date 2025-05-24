using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum EURole
    {
        User = 0,
        Teacher = 1,
        Organizer = 10,
        ServiceProvider = 100,
        Administrator = 1000,
        IsBanned  = -1
    }
}
