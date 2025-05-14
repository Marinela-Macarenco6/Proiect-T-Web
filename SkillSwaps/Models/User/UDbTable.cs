using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace SkillSwaps.Models.User
{
	public class UDbTable
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[Display(Name = "username")]
        [StringLength(30,MinimumLenght =5 , ErrorMessage = "The field minimum chars 5 and maxim is 30")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "The field minimum chars 8 and maxim is 50")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "email")]
        [StringLength(30, MinimumLenght = 5, ErrorMessage = "The field minimum chars 5 and maxim is 30")]
        public string Email { get; set; }
    }
}