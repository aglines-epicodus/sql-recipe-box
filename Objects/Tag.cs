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
///////////////////////////////////////////////
    public override bool Equals(System.Object otherTag)
    {
      if (!(otherTag is Tag))
      {
        return false;
      }
      else
      {
        Tag newTag = (Tag) otherTag;
        bool nameEquality = this.GetName() == newTag.GetName();
        bool idEquality = this.GetId() == newTag.GetId();

        return (nameEquality && idEquality);
      }
    }

///////////////////////////////////////////////
        public void Save()
        {
          SqlConnection conn = DB.Connection();
          conn.Open();

          SqlCommand cmd = new SqlCommand("INSERT INTO tags (name) OUTPUT INSERTED.id VALUES (@Name)", conn);

          SqlParameter nameParam = new SqlParameter("@Name", this.GetName());
          cmd.Parameters.Add(nameParam);

          SqlDataReader rdr = cmd.ExecuteReader();

          while (rdr.Read())
          {
            this._id = rdr.GetInt32(0);
          }

          if(rdr != null)
          {
            rdr.Close();
          }
          if(conn != null)
          {
            conn.Close();
          }

        }


///////////////////////////////////////////////
    public static List<Tag> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tags", conn);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Tag> allTags = new List<Tag>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);

        Tag newTag = new Tag(name, id);
        allTags.Add(newTag);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }

      return allTags;
    }

///////////////////////////////////////////////
    public void AddRecipe(Recipe newRecipe)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO join_recipes_tags (id_recipes, id_tags) VALUES (@RecipeId, @TagId)", conn);

      SqlParameter RecipeIdParam = new SqlParameter();
      RecipeIdParam.ParameterName = "@RecipeId";
      RecipeIdParam.Value = newRecipe.GetId();

      SqlParameter TagIdParam = new SqlParameter();
      TagIdParam.ParameterName = "@TagId";
      TagIdParam.Value = this.GetId();
      cmd.Parameters.Add(RecipeIdParam);
      cmd.Parameters.Add(TagIdParam);

      cmd.ExecuteNonQuery();
      if(conn!=null)
      {
        conn.Close();
      }
    }

///////////////////////////////////////////////
    public List<Recipe> GetRecipes()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT recipes.* FROM tags JOIN join_recipes_tags ON (tags.id = join_recipes_tags.id_tags) JOIN recipes ON (recipes.id = join_recipes_tags.id_recipes) WHERE tags.id = @TagId", conn);

      SqlParameter TagIdParam = new SqlParameter();
      TagIdParam.ParameterName = "@TagId";
      TagIdParam.Value = this.GetId().ToString();

      cmd.Parameters.Add(TagIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Recipe> allRecipes = new List<Recipe>{};

      while (rdr.Read())
      {
        int recipeId = rdr.GetInt32(0);
        string recipeName = rdr.GetString(1);
        string recipeInstructions = rdr.GetString(2);

        Recipe newRecipe = new Recipe(recipeName, recipeInstructions, recipeId);
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


///////////////////////////////////////////////
    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE tags SET name = @NewName OUTPUT INSERTED.name WHERE id = @TagId", conn);

      SqlParameter newNameParam = new SqlParameter();
      newNameParam.ParameterName = "@NewName";
      newNameParam.Value = newName;

      SqlParameter tagIdParam = new SqlParameter();
      tagIdParam.ParameterName = "@TagId";
      tagIdParam.Value = this.GetId();

      cmd.Parameters.Add(newNameParam);
      cmd.Parameters.Add(tagIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        this._name = rdr.GetString(0);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

///////////////////////////////////////////////
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM tags;", conn);
      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }



///////////////////////////////////////////////



  }
}
