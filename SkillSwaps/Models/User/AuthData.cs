using System.ComponentModel.DataAnnotations;

namespace SkillSwaps.Models.User
{
    public class AuthData
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
