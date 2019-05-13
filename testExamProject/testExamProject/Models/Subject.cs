using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testExamProject.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}