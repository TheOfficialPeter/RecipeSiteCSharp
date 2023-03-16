using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Xml.Linq;
using System.Web.Services;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Web.Configuration;
using System.Text;

namespace Advanced_CSharp_Project_3_Web_Service
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnection conn;

        [WebMethod]
        public bool connectToDB()
        {
            try
            {
                conn = new SqlConnection("Integrated Security=true; Initial Catalog=Recipes; Data Source=ZADBV-D00000290");
                conn.Open();

                return true;
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        [WebMethod]
        public void disconnectFromDB()
        {
            conn.Close();
        }


        [WebMethod]
        public bool checkIfUserExist(string username)
        {
            try
            {
                connectToDB();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM Users WHERE username='{0}'", username);
                SqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows == true)
                {
                    disconnectFromDB();
                    return true;
                }
                else
                {
                    disconnectFromDB();
                    return false;
                }
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        [WebMethod]
        public bool addUser(string email, string username, string password, string security)
        {
            try
            {
                connectToDB();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("USE [Recipes] INSERT INTO [Users] VALUES ('{0}', '{1}', '{2}', '{3}')", email, username, password, security);
                cmd.ExecuteNonQuery();

                disconnectFromDB();
                return true;
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        [WebMethod]
        public bool removeUser(string username)
        {
            try
            {
                connectToDB();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("USE [Recipes] DELETE FROM [Users] WHERE username='{0}'", username);
                cmd.ExecuteNonQuery();

                disconnectFromDB();
                return true;
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }


        [WebMethod]
        public bool validateUserWithSecurity(string email, string security)
        {
            try
            {
                connectToDB();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM Users WHERE security_='{0}' AND email='{1}'", security, email);
                SqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows == true)
                {
                    disconnectFromDB();
                    return true;
                }
                else
                {
                    disconnectFromDB();
                    return false;
                }
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        [WebMethod]
        public bool validateUser(string username, string password)
        {
            try
            {
                connectToDB();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM Users WHERE password_='{0}' AND username='{1}'", password, username);
                SqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows == true)
                {
                    disconnectFromDB();
                    return true;
                }
                else
                {
                    disconnectFromDB();
                    return false;
                }
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        [WebMethod]
        public bool resetPassword(string email, string securityQuestion, string password)
        {
            try
            {
                if (validateUserWithSecurity(email, securityQuestion) == true)
                {
                    connectToDB();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = String.Format("UPDATE Users SET password_='{0}' WHERE email='{1}'", password, email);
                    cmd.ExecuteNonQuery();

                    disconnectFromDB();
                    return true;
                }
                else
                {
                    disconnectFromDB();
                    return false;
                }
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        [WebMethod]
        public bool addRecipe(string recipeName, string recipeOwner, string recipeIngredients, string recipeMethod)
        {
            try
            {
                connectToDB();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Recipes";
                SqlDataReader result = cmd.ExecuteReader();
                int Position = 0;

                if (result.HasRows == true)
                {
                    while (result.Read())
                    {
                        Position = Int32.Parse(result.GetValue(0).ToString());
                        Position = Position + 1;
                    }
                }
                result.Close();

                cmd.CommandText = String.Format("INSERT INTO Recipes(recipeNum, recipeName, recipeRating, recipeOwner) VALUES('{0}', '{1}', '{2}', '{3}')", Position, recipeName, 0, recipeOwner);
                cmd.ExecuteNonQuery();

                cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("INSERT INTO RecipeInformation(recipeNum, recipeIngredients, recipeMethod) VALUES('{0}', '{1}', '{2}')", Position, recipeIngredients, recipeMethod);
                cmd.ExecuteNonQuery();

                disconnectFromDB();
                return true;
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        [WebMethod]
        public bool rateRecipe(string recipeNum, int value)
        {
            try
            {
                connectToDB();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("UPDATE Recipes SET recipeRating='{0}' WHERE recipeNum ='{1}'", value, Int32.Parse(recipeNum));
                cmd.ExecuteNonQuery();

                disconnectFromDB();
                return true;
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }

        [WebMethod]
        public string getRecipeTitle(string recipeNum)
        {
            try
            {
                connectToDB();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM Recipes WHERE recipeNum='{0}'", Int32.Parse(recipeNum));
                SqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows == true)
                {
                    while (result.Read())
                    {
                        return result.GetValue(1).ToString();
                    }
                }
                disconnectFromDB();
                return "";

            }
            catch
            {
                return "";
            }
        }

        [WebMethod]
        public string getRecipeIngredients(string recipeNum)
        {
            try
            {
                connectToDB();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM RecipeInformation WHERE recipeNum='{0}'", Int32.Parse(recipeNum));
                SqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows == true)
                {
                    while (result.Read())
                    {
                        return result.GetValue(1).ToString();
                    }
                }
                disconnectFromDB();
                return "";
            }
            catch
            {
                return "";
            }
        }

        [WebMethod]
        public string getRecipeMethod(string recipeNum)
        {
            try
            {
                connectToDB();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("SELECT * FROM RecipeInformation WHERE recipeNum='{0}'", Int32.Parse(recipeNum));
                SqlDataReader result = cmd.ExecuteReader();

                if (result.HasRows == true)
                {
                    while (result.Read())
                    {
                        return result.GetValue(2).ToString();
                    }
                }
                disconnectFromDB();
                return "";
            }
            catch
            {
                return "";
            }
        }


        [WebMethod]
        public bool removeRecipe(string recipeName, string recipeOwner)
        {
            try
            {
                connectToDB();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = String.Format("DELETE FROM Recipes WHERE recipeName='{0}' AND recipeOwner='{1}'", recipeName, recipeOwner);
                cmd.ExecuteNonQuery();

                disconnectFromDB();
                return true;
            }
            catch (SqlException sqlError)
            {
                return false;
            }
        }
    }
}
