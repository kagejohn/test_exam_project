using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using testExamProject.Models;

namespace testExamProject.TestData
{
    public class TestData
    {
        private readonly Random _random = new Random();
        private readonly List<Student> _students = new List<Student>();

        TestData()
        {
            
        }

        private void CreateStudents(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    try
                    {
                        command.CommandText = "INSERT INTO Student (Name, Age) VALUES ('@Name', '@Age');";
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = RandomString(10) + " " + RandomString(10);
                        command.Parameters.Add("@Age", SqlDbType.Int).Value = _random.Next(18, 30);


                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }
            }
        }

        private void CreateTeachers(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    try
                    {
                        command.CommandText = "INSERT INTO Teacher (Name, Education, Teaching) VALUES ('@Name', '@Education', '@Teaching');";
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = RandomString(10) + " " + RandomString(10);
                        command.Parameters.Add("@Education", SqlDbType.NVarChar).Value = Convert.ToBoolean(_random.Next(2)).ToString();
                        command.Parameters.Add("@Teaching", SqlDbType.NVarChar).Value = Convert.ToBoolean(_random.Next(2)).ToString();


                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }
            }
        }

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}