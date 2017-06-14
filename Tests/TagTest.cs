using Xunit;
using RecipeBox.Objects;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBox
{
  [Collection("RecipeBox")]

  public class TagTests : IDisposable
  {
    public TagTests()
    {
    DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=recipebox_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Tag_DatabaseIsEmpty_True()
    {
      //Arrange:  manual data
      List<Tag> expectedList = new List<Tag>{};
      //Act : the method we're testing
      List<Tag> resultList = Tag.GetAll();
      // Assert
      Assert.Equal(expectedList, resultList);
    }

    ////////////////////////////////////////////////////////////

    [Fact]
    public void Tag_Equals_TrueForIdenticalObjects()
    {
      Tag firstTag = new Tag("dinner");
      Tag secondTag = new Tag("dinner");
      Assert.Equal(firstTag, secondTag);
    }

    ////////////////////////////////////////////////////////////

    [Fact]
    public void Tag_Save_SavesTagToDb()
    {
      Tag newTag = new Tag("dinner");

      newTag.Save();
      Tag savedTag = Tag.GetAll()[0];

      Assert.Equal(newTag, savedTag);
    }

    ////////////////////////////////////////////////////////////

    [Fact]
    public void Recipe_AddRecipesToOneTag_True()
    {
      //arrange manual data
      Tag newTag = new Tag("soupy");
      newTag.Save();

      Recipe firstRecipe = new Recipe("soup", "heat up");
      Recipe secondRecipe = new Recipe("another soup", "heat up");
      firstRecipe.Save();
      secondRecipe.Save();

      newTag.AddRecipe(firstRecipe);
      newTag.AddRecipe(secondRecipe);

      List<Recipe> result = newTag.GetRecipes();
      List<Recipe> expected = new List<Recipe>{firstRecipe, secondRecipe};

    }

////////////////////////////////////////////////////////////
  [Fact]
  public void GetRecipes_ReturnAllRecipesFromOneTag_True()
  {
    Tag testTag = new Tag("hearty");
    testTag.Save();

    Recipe firstRecipe = new Recipe("soup", "heat");
    Recipe secondRecipe = new Recipe("burger", "fry");
    firstRecipe.Save();
    secondRecipe.Save();

    testTag.AddRecipe(firstRecipe);
    testTag.AddRecipe(secondRecipe);
    List<Recipe> expectedRecipes = new List<Recipe>{firstRecipe, secondRecipe};
    List<Recipe> resultRecipes = testTag.GetRecipes();

    Assert.Equal(expectedRecipes, resultRecipes);
  }



////////////////////////////////////////////////////////////

    [Fact]
    public void Dispose()
    {
      Tag.DeleteAll();
      Recipe.DeleteAll();
    }
  }
}
