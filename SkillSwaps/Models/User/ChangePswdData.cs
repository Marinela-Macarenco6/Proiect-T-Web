﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillSwaps.Models.User
{
	public class ChangePswdData
	{
		public string OldPassword { get; set; }
        public string NewPassword { get; set; }
		public string ConfirmPassword { get; set; }
    }
}