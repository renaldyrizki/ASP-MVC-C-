using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab01_151524026_Renaldy.Models
{

    [Table("Club")] //nama table
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }

        [Required]
        [Display(Name = "Club Name")]
        [StringLength(255)]
        public string ClubName { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(225)]
        public string Motto { get; set; }

        [Required]
        [Display(Name = "Estabilished Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EstabilishedDate { get; set; }

        public virtual ICollection<Member> Member { get; set; }
    }
}