using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using RecipeBox.Objects;


namespace RecipeBox
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      // root -> list all recipes
      Get["/"] = _ => {
        List<Recipe> allRecipes = Recipe.GetAll();
        return View["index.cshtml", allRecipes];
      };

      // recipes add
      Get["/recipes/add"] = _ => {
        Post[""]
      };

    }
  }
}
