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

    [Fact]
    public void Dispose()
    {
      Tag.DeleteAll();
    }
  }
}
