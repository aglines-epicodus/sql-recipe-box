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
////////////////////////////////////////////////////////////
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

////////////////////////////////////////////////////////////
    [Fact]
    public void Recipe_Equals_TrueForIdenticalObjects()
    {
      Recipe firstRecipe = new Recipe("soup", "heat up");
      Recipe secondRecipe = new Recipe("soup", "heat up");
      Assert.Equal(firstRecipe, secondRecipe);
    }

////////////////////////////////////////////////////////////
    [Fact]
    public void Recipe_Save_SavesRecipeToDb()
    {
      Recipe newRecipe = new Recipe("soup", "heat up");

      newRecipe.Save();
      Recipe savedRecipe = Recipe.GetAll()[0];

      Assert.Equal(newRecipe, savedRecipe);
    }

////////////////////////////////////////////////////////////
    [Fact]
    public void Tag_AddTagsToOneRecipe_True()
    {
      //arrange = manual data
      // add one recipe and two tags
      Recipe newRecipe = new Recipe("soup", "heat up");
      newRecipe.Save();

      Tag firstTag = new Tag("first");
      Tag secondTag = new Tag("second");
      firstTag.Save();
      secondTag.Save();

    //Act
      newRecipe.AddTag(firstTag);
      newRecipe.AddTag(secondTag);

      List<Tag> result = newRecipe.GetTags();
      List<Tag> expected = new List<Tag>{firstTag, secondTag};

      Assert.Equal(result, expected);
    }
////////////////////////////////////////////////////////////

    [Fact]
    public void GetTags_ReturnAllTagsFromOneRecipe_True()
    {
      Recipe testRecipe = new Recipe("soup", "heat the soup");
      testRecipe.Save();

      Tag firstTag = new Tag("soupy");
      Tag secondTag = new Tag("tasty");
      firstTag.Save();
      secondTag.Save();

      testRecipe.AddTag(firstTag);
      testRecipe.AddTag(secondTag);
      List<Tag> expectedTags = new List<Tag>{firstTag, secondTag};
      List<Tag> resultTags = testRecipe.GetTags();

      Assert.Equal(resultTags, expectedTags);
    }

////////////////////////////////////////////////////////////
    [Fact]
    public void Update_UpdatesRecipeNameInDb_True()
    {
      string name = "soup";
      string instructions = "heat up";
      Recipe testRecipe = new Recipe(name, instructions);
      testRecipe.Save();

      string newName = "burgers";
      string newInstructions = "fry";
      testRecipe.Update(newName, newInstructions);

      string resultName = testRecipe.GetName();

      Assert.Equal(resultName, "burgers");
    }
////////////////////////////////////////////////////////////
    // [Fact]
    // public void Delete_DeleteSingleFromDb_True()
    // {
    //   string name = "bad food";
    //   string instructions = "throw it in the trash";
    //   Recipe testRecipe = new Recipe(name, instructions);
    //   testRecipe.Save();
    //
    //   Recipe.Delete();
    //
    //   expectedName
    //
    //   Assert.Equal()
    // }



////////////////////////////////////////////////////////////
    [Fact]
    public void Dispose()
    {
      Recipe.DeleteAll();
      Tag.DeleteAll();
    }
  }
}
