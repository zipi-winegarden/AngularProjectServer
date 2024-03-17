using angular_server;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    

    // GET: api/Recipe
    [HttpGet]
    public IEnumerable<Recipe> Get()
    {
        return Data.Recipes;
    }

    // GET: api/Recipe/5
    [HttpGet("{id}", Name = "Get")]
    public ActionResult<Recipe> Get(int id)
    {
        var recipe = Data.Recipes.FirstOrDefault(r => r.RecipeCode == id);
        if (recipe == null)
        {
            return NotFound();
        }
        return recipe;
    }

    // POST: api/Recipe
    [HttpPost]
    public ActionResult Post([FromBody] Recipe recipe)
    {
        Data.Recipes.Add(recipe);
        return CreatedAtAction(nameof(Get), new { id = recipe.RecipeCode }, recipe);
    }

    // PUT: api/Recipe/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Recipe recipe)
    {
        var existingRecipe = Data.Recipes.FirstOrDefault(r => r.RecipeCode == id);
        if (existingRecipe == null)
        {
            return NotFound();
        }
        existingRecipe.RecipeName = recipe.RecipeName;
        existingRecipe.CategoryCode = recipe.CategoryCode;
        existingRecipe.PreparationTimeMinutes = recipe.PreparationTimeMinutes;
        existingRecipe.DifficultyLevel = recipe.DifficultyLevel;
        existingRecipe.DateAdded = recipe.DateAdded;
        existingRecipe.Ingredients = recipe.Ingredients;
        existingRecipe.PreparationMethod = recipe.PreparationMethod;
        existingRecipe.UserCode = recipe.UserCode;
        existingRecipe.ImageRouting = recipe.ImageRouting;

        return NoContent();
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var recipe = Data.Recipes.FirstOrDefault(r => r.RecipeCode == id);
        if (recipe == null)
        {
            return NotFound();
        }
        Data.Recipes.Remove(recipe);
        return NoContent();
    }
}
