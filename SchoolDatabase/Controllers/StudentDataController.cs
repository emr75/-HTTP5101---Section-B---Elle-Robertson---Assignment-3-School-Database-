using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolDatabase.Models;
using MySql.Data.MySqlClient;


namespace SchoolDatabase.Controllers
{
    public class StudentDataController : ApiController
    {

        //The SchooldbContext is a database context class which allows us to access our mySQL Database known as schooldb.
        private SchoolDbContext SchoolDatabase = new SchoolDbContext();

        //This controller will access the students table of the schooldb database
        /// <summary>
        /// Returns a list of students in the system
        /// </summary>
        /// <example>GET api/StudentData/ListStudents</example>
        /// <returns>
        /// A list of students (first names and last names)
        /// </returns>
        [HttpGet]

        public IEnumerable<Student> ListStudents()
        {
            //Instance of a connection
            MySqlConnection Conn = SchoolDatabase.AccessDatabase();

            //Connection between the web server and database
            Conn.Open();

            //Established a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query from student table
            cmd.CommandText = "Select * from Students";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Students' names
            List<Student> Students = new List<Student> { };

            //Loop through each row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by ther DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = (string)ResultSet["studentfname"];
                string StudentLname = (string)ResultSet["studentlname"];
                string StudentNumber = (string)ResultSet["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];

                //Creating a NewStudent object from the student class and using the above objects to create properties of this NewStudent object

                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;

                //Add the student name to the List
                Students.Add(NewStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();


            //Return the final list of Student names
            return Students;
        }

        [HttpGet]
        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();

            //Create an instance of a connection
            MySqlConnection Conn = SchoolDatabase.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from Students where studentid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by ther DB column name as an index
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFname = (string)ResultSet["studentfname"];
                string StudentLname = (string)ResultSet["studentlname"];
                string StudentNumber = (string)ResultSet["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];

                //Creating a NewStudent object for FindStudent from the student class and using the above objects to create properties of this NewStudent object

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;

            }

            //Close the connection between the MySQL Database, schooldb and the WebServer
            Conn.Close();

            //return student object

            return NewStudent;
        }
    }
}
