public class Recipe
{
    private int _difficultyLevel;

    public int RecipeCode { get; set; }
    public string RecipeName { get; set; }
    public int CategoryCode { get; set; }
    public int PreparationTimeMinutes { get; set; }
    public int DifficultyLevel
    {
        get => _difficultyLevel;
        set
        {
            if (value < 1 || value > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(DifficultyLevel), "Difficulty level must be between 1 and 5.");
            }
            _difficultyLevel = value;
        }
    }
    public DateTime DateAdded { get; set; }
    public List<string> Ingredients { get; set; }
    public List<string> PreparationMethod { get; set; }
    public int UserCode { get; set; }
    public string ImageRouting { get; set; }
}
