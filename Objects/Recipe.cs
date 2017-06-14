using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace RecipeBox.Objects
{
  public class Recipe
  {
    private int _id;
    private string _name;
    private string _instructions;

    public Recipe(string Name, string Instructions, int Id = 0)
    {
      _name = Name;
      _instructions = Instructions;
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
    public string GetInstructions()
    {
      return _instructions;
    }
    public void SetInstructions(string newInstructions)
    {
      _instructions = newInstructions;
    }
///////////////////////////////////////////////
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM recipes;", conn);
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }
///////////////////////////////////////////////
    public static List<Recipe> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM recipes", conn);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Recipe> allRecipes = new List<Recipe>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string instructions = rdr.GetString(2);

        Recipe newRecipe = new Recipe(name, instructions, id);
        allRecipes.Add(newRecipe);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return allRecipes;
    }




























  }
}
