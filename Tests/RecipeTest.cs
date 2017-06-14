using Xunit;
using RecipeBox.Objects;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RecipeBox
{
  [Collection("RecipeBox")]

  public class RecipeTest : IDisposable
  {
    public RecipeTest()
    {
    DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=recipebox_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Recipe_DatabaseIsEmpty_True()
    {
      //Arrange:  manual data
      List<Recipe> expectedList = new List<Recipe>{};
      //Act : the method we're testing
      List<Recipe> resultList = Recipe.GetAll();
      // Assert
      Assert.Equal(expectedList, resultList);
    }


    [Fact]
    public void Recipe_Equals_TrueForIdenticalObjects()
    {
      Recipe firstRecipe = new Recipe("soup", "heat up");
      Recipe secondRecipe = new Recipe("soup", "heat up");
      Assert.Equal(firstRecipe, secondRecipe);
    }


    [Fact]
    public void Recipe_Save_SavesRecipeToDb()
    {
      Recipe newRecipe = new Recipe("soup", "heat up");

      newRecipe.Save();
      Recipe savedRecipe = Recipe.GetAll()[0];

      Assert.Equal(newRecipe, savedRecipe);
    }




    [Fact]
    public void Dispose()
    {
      Recipe.DeleteAll();
    }
  }
}
