using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.User
{
    public class UserRegData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Full Name must be between 5 and 50 characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "User Name must be between 5 and 30 characters.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Email Address must be between 5 and 70 characters.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 50 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "request_time")]
        public DateTime? RequestTime { get; set; }

        [Display(Name = "role")]
        public EURole userRole { get; set; }


    }
}

