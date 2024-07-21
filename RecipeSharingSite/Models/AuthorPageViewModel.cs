namespace RecipeSharingSite.Models
{
    public class AuthorPageViewModel
    {
        public Author Author { get; set; }
        public ICollection<Recipe> RecipeList { get; set; }
    }
}
