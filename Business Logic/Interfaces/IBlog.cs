﻿using SkillSwaps.Domain.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.Interfaces
{
    public interface IBlog
    {
        bool SaveComment(CTable data);
    }
}
