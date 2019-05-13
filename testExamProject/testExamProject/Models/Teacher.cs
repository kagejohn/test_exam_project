using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testExamProject.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Education { get; set; }
        public bool Teaching { get; set; }
    }
}