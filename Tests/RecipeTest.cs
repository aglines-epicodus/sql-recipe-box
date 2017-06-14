using Xunit;
using AirlinePlanner.Objects;
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
    public void Recipe_DatabaseIsEmpty_True
    {
      //Arrange:  manual data
      List<Recipe> expectedList = new List<Recipe>{};
      //Act : the method we're testing
      List<Recipe> resultList = Recipe.GetAll();
      // Assert
      Assert.Equal(expectedList, resultList);
    }

    [Fact]
    public void Dispose()
    {
      Recipe.DeleteAll();
    }
  }
}
