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


  }
}
