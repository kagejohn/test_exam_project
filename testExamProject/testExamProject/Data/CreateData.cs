using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace testExamProject.Data
{
    public class CreateData
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool CreateStudents(string name, int age)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand { Connection = connection };

                try
                {
                    command.CommandText = "INSERT INTO Student (Name, Age) VALUES (@Name, @Age);";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add("@Age", SqlDbType.Int).Value = age;


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                }
                catch (Exception)
                {
                    return false;
                    // ignored
                }
            }

            return true;
        }

        public bool CreateTeachers(string name, string education, bool teaching)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand { Connection = connection };

                try
                {
                    command.CommandText = "INSERT INTO Teacher (Name, Education, Teaching) VALUES (@Name, @Education, @Teaching);";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add("@Education", SqlDbType.NVarChar).Value = education;
                    command.Parameters.Add("@Teaching", SqlDbType.Bit).Value = teaching;


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                }
                catch (Exception)
                {
                    return false;
                    // ignored
                }
            }

            return true;
        }

        public void CreateCourses(string name, int duration, int teacherId)
        {
            CreateCourses(name, duration, DateTime.Today, teacherId);
        }

        public bool CreateCourses(string name, int duration, DateTime addedDate, int teacherId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand { Connection = connection };

                try
                {
                    command.CommandText = "INSERT INTO Course (Name, Duration, AddedDate, TeacherId) VALUES (@Name, @Duration, @AddedDate, @TeacherId);";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                    command.Parameters.Add("@Duration", SqlDbType.Int).Value = duration;
                    command.Parameters.Add("@AddedDate", SqlDbType.Date).Value = addedDate.Date;
                    command.Parameters.Add("@TeacherId", SqlDbType.Int).Value = teacherId;


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                }
                catch (Exception)
                {
                    return false;
                    // ignored
                }
            }

            return true;
        }

        public bool CreateCourseParticipations(int studentId, int courseId, bool paid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand { Connection = connection };

                try
                {
                    command.CommandText = "INSERT INTO CourseParticipation (StudentID, CourseID, Paid) VALUES (@StudentID, @CourseID, @Paid);";
                    command.Parameters.Add("@StudentID", SqlDbType.Int).Value = studentId;
                    command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseId;
                    command.Parameters.Add("@Paid", SqlDbType.Bit).Value = paid;


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                }
                catch (Exception)
                {
                    return false;
                    // ignored
                }
            }

            return true;
        }

        public bool CreateSubjects(string name)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand { Connection = connection };

                try
                {
                    command.CommandText = "INSERT INTO Subject (Name) VALUES (@Name);";
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                }
                catch (Exception)
                {
                    return false;
                    // ignored
                }
            }

            return true;
        }

        public bool CreateCourseSubjects(int subjectId, int courseId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand { Connection = connection };

                try
                {
                    command.CommandText = "INSERT INTO CourseSubjects (SubjectID, CourseID) VALUES (@SubjectID, @CourseID);";
                    command.Parameters.Add("@SubjectID", SqlDbType.Int).Value = subjectId;
                    command.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseId;


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                    }
                }
                catch (Exception)
                {
                    return false;
                    // ignored
                }
            }

            return true;
        }
    }
}