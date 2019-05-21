using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using testExamProject.Models;

namespace testExamProject.Data
{
    public class LoadTestData
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Teacher> GetTeachersForCoursesThatWillNotStart(int id)
        {
            List<Teacher> teachers = new List<Teacher>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand {Connection = connection};

                try
                {
                    command.CommandText = "select Teacher.* from Course join Teacher on Course.TeacherId = Teacher.Id where Participants < 12";
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Teacher teacher = new Teacher();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader.GetName(i) == "Id")
                            {
                                teacher.Id = (int)reader.GetValue(i);
                            }
                            if (reader.GetName(i) == "Name")
                            {
                                teacher.Name = (string)reader.GetValue(i);
                            }
                            if (reader.GetName(i) == "Education")
                            {
                                teacher.Education = (string)reader.GetValue(i);
                            }
                            if (reader.GetName(i) == "Teaching")
                            {
                                teacher.Teaching = (bool)reader.GetValue(i);
                            }
                        }
                        teachers.Add(teacher);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                }
            }

            return teachers;
        }
    }
}