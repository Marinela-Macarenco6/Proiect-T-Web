using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.User
{
    public class UDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "username")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The field minimum chars 5 and maxim is 30")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The field minimum chars 8 and maxim is 50")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "email")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "The field minimum chars 5 and maxim is 30")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Display(Name = "reg_dt")]
        public DateTime RegistrationDateTime { get; set; }

        [Display(Name = "login_dt")]
        public DateTime LastLoginGateTime { get; set; }

        [Display(Name = "u_level")]
        public URole Level { get; set; }

    }
}
