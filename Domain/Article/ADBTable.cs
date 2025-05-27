using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Article
{
    public class ADBTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "title")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Title can not be shorter than 4 charatcters and longer than 30 characters")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "teacher")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Teacher can not be shorter than 4 charatcters and longer than 30 characters")]
        public string Teacher { get; set; }

        [Required]
        [Display(Name = "category")]
        public EACategory Category { get; set; }

        [Required]
        [Display(Name = "description")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description cant be shorter than 10 charatcters and longer than 200 characters")]
        public string Description { get; set; }

        [Display(Name = "publication_dt")]
        public DateTime PublicationDateTime { get; set; }

        [Display(Name = "enrolled_users")]
        public int EnrolledUsers { get; set; }


    }
}
