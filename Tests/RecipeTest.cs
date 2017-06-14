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

    public void Dispose()
    {
      Recipe.DeleteAll();
    }
  }
}
