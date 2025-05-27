using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkillSwaps.Models.Course
{
	public class AddCourseData
	{
        public string Title { get; set; }
        public string Teacher { get; set; }
        public EACategory Category { get; set; }
        public string Description { get; set; }

    }

}