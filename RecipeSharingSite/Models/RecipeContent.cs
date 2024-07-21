using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSharingSite.Models
{
    public class RecipeContent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string key { get; set; }

        public string value { get; set; }

       public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
       public Recipe Recipe { get; set; }

    
    }
}
