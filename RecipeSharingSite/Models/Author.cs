using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharingSite.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Password { get; set; }

        public List<Recipe> RecipeList { get; set; }   
    }
}
