using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace RecipeBox.Objects
{
  public class Tag
  {
    private int _id;
    private string _name;

    public Tag(string Name, int Id = 0)
    {
      _name = Name;
      _id = Id;
    }

    public int GetId()
    {
      return _id;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }



  }
}
