using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Literally dont be an idiot you have to enter a title!")]
        public string Title { get; set; }
         
        [Required(ErrorMessage = "Literally dont be an idiot you have to enter a year!")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Literally dont be an idiot you have to enter a director!")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Literally dont be an idiot you have to enter a rating!")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }


        // Build Foreign Key Relationship
        [Required(ErrorMessage = "Literally dont be an idiot you have to enter a category!")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
