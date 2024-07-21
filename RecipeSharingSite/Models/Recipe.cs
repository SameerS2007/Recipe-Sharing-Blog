using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.ComponentModel.DataAnnotations;
namespace RecipeSharingSite.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> IngredientList { get; set; }
        public int Calories { get; set; }
        public int Upvotes { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<RecipeContent> Contents { get; set; } = new List<RecipeContent>();
  
    }
}

