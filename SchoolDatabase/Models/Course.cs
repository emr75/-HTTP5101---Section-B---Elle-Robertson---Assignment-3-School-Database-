using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDatabase.Models
{
    public class Course
    {
        //The following properties define a Course Class
        public int CourseId;
        public string CourseCode;
        public Int64 TeachId;
        public DateTime StartDate;
        public DateTime FinishDate;
        public string CourseName;
    }
}