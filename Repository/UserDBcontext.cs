using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication13.Models;
using System.Dynamic;
using System.Web.Mvc;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Collections;

namespace WebApplication13.Repository
{
    public class UserDBcontext
    {
        string conString = ConfigurationManager.ConnectionStrings["DBconnect"].ToString();

        //Get all the User Details
        public List<Signup> GetallUser()
        {
            List<Signup> signuplist = new List<Signup>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Get_ALL_NewUser";
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                da.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    const string V = "DateofBirth";
                    signuplist.Add(
                        new Signup
                        {
                            id = Convert.ToInt32(dr["id"]),
                            Firstname = Convert.ToString(dr["Firstname"]),
                            Lastname = Convert.ToString(dr["Lastname"]),
                            Username = Convert.ToString(dr["Username"]),
                            Registernumber = Convert.ToString(dr["Registernumber"]),
                            DateofBirth = Convert.ToDateTime(dr[V]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Email = Convert.ToString(dr["Email"]),
                            Password = Convert.ToString(dr["Password"]),
                            ConfirmPassword = Convert.ToString(dr["ConfirmPassword"]),
                            Address = Convert.ToString(dr["Address"]),
                            State = Convert.ToString(dr["State"]),
                            District = Convert.ToString(dr["District"])

                        });
                }

                return signuplist;
            }
        }

        // Create a New user

        public bool AddUser(Signup sign)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("Add_NewUser1", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Firstname", sign.Firstname);

                command.Parameters.AddWithValue("@Lastname", sign.Lastname);
                command.Parameters.AddWithValue("@Username", sign.Username);
                command.Parameters.AddWithValue("@Registernumber", sign.Registernumber);
                command.Parameters.AddWithValue("@DateofBirth", value: sign.DateofBirth);
                command.Parameters.AddWithValue("@Gender", sign.Gender);

                command.Parameters.AddWithValue("@Email", sign.Email);
                command.Parameters.AddWithValue("@Password", sign.Password);
                command.Parameters.AddWithValue("@ConfirmPassword", sign.ConfirmPassword);
                command.Parameters.AddWithValue("@Address", sign.Address);
                command.Parameters.AddWithValue("@State", sign.State);
                command.Parameters.AddWithValue("@District", sign.District);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Get a Selected User Details


        public List<Signup> GetaUserById(int id)
        {
            List<Signup> signuplist = new List<Signup>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Select_NewUser";
                command.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                connection.Open();
                da.Fill(dt);
                connection.Close();

                foreach (DataRow dr in dt.Rows)
                    signuplist.Add(
                        new Signup
                        {
                            id = Convert.ToInt32(dr["id"]),
                            Firstname = Convert.ToString(dr["Firstname"]),
                            Lastname = Convert.ToString(dr["Lastname"]),
                            Username = Convert.ToString(dr["Username"]),
                            Registernumber = Convert.ToString(dr["Registernumber"]),
                            DateofBirth = Convert.ToDateTime(dr["DateofBirth"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Email = Convert.ToString(dr["Email"]),
                            Password = Convert.ToString(dr["Password"]),
                            ConfirmPassword = Convert.ToString(dr["ConfirmPassword"]),
                            Address = Convert.ToString(dr["Address"]),
                            State = Convert.ToString(dr["State"]),
                            District = Convert.ToString(dr["District"])

                        });

                return signuplist;
            }
        }


        // Update the user Details


        public bool UpdateUser(Signup sign)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("Update_NewUser", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", sign.id);
                command.Parameters.AddWithValue("@Firstname", sign.Firstname);
                command.Parameters.AddWithValue("@Lastname", sign.Lastname);
                command.Parameters.AddWithValue("@Username", sign.Username);
                command.Parameters.AddWithValue("@Registernumber", sign.Registernumber);
                command.Parameters.AddWithValue("@DateofBirth", sign.DateofBirth);
                command.Parameters.AddWithValue("@Gender", sign.Gender);

                command.Parameters.AddWithValue("@Email", sign.Email);
                command.Parameters.AddWithValue("@Password", sign.Password);
                command.Parameters.AddWithValue("@ConfirmPassword", sign.ConfirmPassword);
                command.Parameters.AddWithValue("@Address", sign.Address);
                command.Parameters.AddWithValue("@State", sign.State);
                command.Parameters.AddWithValue("@District", sign.District);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        // Delete the user details

        public string DeleteUser(int id)
        {

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("Delete_NewUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return connection.ConnectionString;
            }

        }


        // Signin 

        public Signup Signin(string username, string password)
        {
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                using (var command = new SqlCommand("Authentication_Login", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Signup
                            {

                                Username = (string)reader["Username"],
                                Password = (string)reader["Password"],

                            };
                        }
                    }
                }
            }

            return null;
        }
        public bool Validate_User(Admin admin)
        {

            using (SqlConnection connection = new SqlConnection(conString))
            {

                SqlCommand cmd = new SqlCommand("Select * from Admin");


                cmd.Parameters.AddWithValue("@Username", admin.Username);
                cmd.Parameters.AddWithValue("@Password", admin.Password);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();

                if (i >= 1)
                    return true;
                else
                    return false;



            }

        }

    }
}
   
