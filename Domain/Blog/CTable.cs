using System;
using System.ComponentModel.DataAnnotations;

namespace SkillSwaps.Domain.Comments
{
    public class CTable
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;
    }
}