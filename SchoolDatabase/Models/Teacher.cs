using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDatabase.Models
{
    public class Teacher
    {
        //The following properties define a Teacher Class
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public decimal Salary;
    
        //parameter-less constructor function for POST data to be absorbed into Teacher object
        public Teacher() { }
    
    
    }
}