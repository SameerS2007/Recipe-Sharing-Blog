namespace RecipeSharingSite.Models
{
    public class RecipeViewViewModel
    {
        public Recipe Recipe { get; set; }
        public ICollection<RecipeContent> Content { get; set; }
    }
}
