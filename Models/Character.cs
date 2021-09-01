using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesCG.Models
{
    public class Character
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime CreatedDate { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Profession { get; set; }
        
        [Range(1,10)]
        [Required]
        public int Level { get; set; }
        
        [Range(0,100)]
        [Required]
        [Display(Name = "Times Played")]
        public int TimesPlayed { get; set; }
    }
}
