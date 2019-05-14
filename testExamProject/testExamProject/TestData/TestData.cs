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
        private int _studentsAmount;
        private int _teachersAmount;
        private int _coursesAmount;
        private int _subjectsAmount;

        public TestData(int amount)
        {
            CreateStudents(amount);
            CreateTeachers(amount / 10);
            CreateCourses(amount / 20);
            CreateCourseParticipations(amount * 3);
            CreateSubjects(amount / 40);
            CreateCourseSubjects(amount / 20);
        }

        private void CreateStudents(int amount)
        {
            _studentsAmount = amount;

            for (int i = 0; i < amount; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    try
                    {
                        command.CommandText = "INSERT INTO Student (Name, Age) VALUES (@Name, @Age);";
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
            _teachersAmount = amount;

            for (int i = 0; i < amount; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    try
                    {
                        command.CommandText = "INSERT INTO Teacher (Name, Education, Teaching) VALUES (@Name, @Education, @Teaching);";
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = RandomString(10) + " " + RandomString(10);
                        command.Parameters.Add("@Education", SqlDbType.NVarChar).Value = Convert.ToBoolean(_random.Next(2)).ToString();
                        command.Parameters.Add("@Teaching", SqlDbType.Bit).Value = Convert.ToBoolean(_random.Next(2));


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

        private void CreateCourses(int amount)
        {
            _coursesAmount = amount;

            for (int i = 0; i < amount; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    try
                    {
                        command.CommandText = "INSERT INTO Course (Name, Participants, Duration, TeacherId) VALUES (@Name, @Participants, @Duration, @TeacherId);";
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = RandomString(10);
                        command.Parameters.Add("@Participants", SqlDbType.Int).Value = _random.Next(20);
                        command.Parameters.Add("@Duration", SqlDbType.Int).Value = _random.Next(20, 30);
                        command.Parameters.Add("@TeacherId", SqlDbType.Int).Value = _random.Next(1, _teachersAmount);


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

        private void CreateCourseParticipations(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    try
                    {
                        command.CommandText = "INSERT INTO CourseParticipation (StudentID, CourseID, Paid) VALUES (@StudentID, @CourseID, @Paid);";
                        command.Parameters.Add("@StudentID", SqlDbType.Int).Value = _random.Next(1, _studentsAmount);
                        command.Parameters.Add("@CourseID", SqlDbType.Int).Value = _random.Next(1, _coursesAmount);
                        command.Parameters.Add("@Paid", SqlDbType.Bit).Value = Convert.ToBoolean(_random.Next(2));


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

        private void CreateSubjects(int amount)
        {
            _subjectsAmount = amount;

            for (int i = 0; i < amount; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    try
                    {
                        command.CommandText = "INSERT INTO Subject (Name) VALUES (@Name);";
                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = RandomString(10);


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

        private void CreateCourseSubjects(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;

                    try
                    {
                        command.CommandText = "INSERT INTO CourseSubjects (SubjectID, CourseID) VALUES (@SubjectID, @CourseID);";
                        command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = _random.Next(1, _subjectsAmount);
                        command.Parameters.Add("@CourseID", SqlDbType.Int).Value = _random.Next(1, _coursesAmount);


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