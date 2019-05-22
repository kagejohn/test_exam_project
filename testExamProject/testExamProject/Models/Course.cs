using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testExamProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Participants { get; set; }
        public int Duration { get; set; }
        public DateTime? AddedDate { get; set; }
        public int TeacherId { get; set; }
        public List<Student> Students { get; set; }
    }
}