using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolDatabase.Models
{
    public class Teacher
    {
        //The following properties define ann teacher
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public decimal Salary;
    }
}