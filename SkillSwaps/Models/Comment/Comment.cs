using System;

namespace SkillSwaps.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }  // <-- nou
        public string Content { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;
    }
}
