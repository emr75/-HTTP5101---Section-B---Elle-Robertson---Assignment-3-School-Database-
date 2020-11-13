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
    public class CourseDataController : ApiController
    {

        //The SchooldbContext is a database context class which allows us to access our mySQL Database known as schooldb.
        private SchoolDbContext SchoolDatabase = new SchoolDbContext();

        //This controller will access the classes table of the schooldb database
        //References including model names, object names, and comments will be labelled as "course" where appropriate in order not to confuse classes with a class within the Visual Studio environment
        /// <summary>
        /// Returns a list of courses in the system
        /// </summary>
        /// <example>GET api/CourseData/ListCourses</example>
        /// <returns>
        /// A list of courses (course name)
        /// </returns>
        [HttpGet]

        public IEnumerable<Course> ListCourses()
        {
            //Instance of a connection
            MySqlConnection Conn = SchoolDatabase.AccessDatabase();

            //Connection between the web server and database
            Conn.Open();

            //Established a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query from classes table
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Course names
            List<Course> Courses = new List<Course> { };

            //Loop through each row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by ther DB column name as an index
                int CourseId = (int)ResultSet["classid"];
                string CourseCode = (string)ResultSet["classcode"];
                Int64 TeachId = (Int64)ResultSet["teacherid"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string CourseName = (string)ResultSet["classname"];

                //Creating a NewCourse object from the course class and using the above objects to create properties of this NewCourse object

                Course NewCourse = new Course();
                NewCourse.CourseId = CourseId;
                NewCourse.CourseCode = CourseCode;
                NewCourse.TeachId = TeachId;
                NewCourse.StartDate = StartDate;
                NewCourse.FinishDate = FinishDate;
                NewCourse.CourseName = CourseName;

                //Add the course name to the List
                Courses.Add(NewCourse);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();


            //Return the final list of author names
            return Courses;
        }

        [HttpGet]
        public Course FindCourse(int id)
        {
            Course NewCourse = new Course();

            //Create an instance of a connection
            MySqlConnection Conn = SchoolDatabase.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from classes where classid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by ther DB column name as an index
                int CourseId = (int)ResultSet["classid"];
                string CourseCode = (string)ResultSet["classcode"];
                Int64 TeachId = (Int64)ResultSet["teacherid"];
                DateTime StartDate = (DateTime)ResultSet["startdate"];
                DateTime FinishDate = (DateTime)ResultSet["finishdate"];
                string CourseName = (string)ResultSet["classname"];

                //Creating a NewCourse object from the course class for FindTeacher and using the above objects to create properties of this NewCourse object

                NewCourse.CourseId = CourseId;
                NewCourse.CourseCode = CourseCode;
                NewCourse.TeachId = TeachId;
                NewCourse.StartDate = StartDate;
                NewCourse.FinishDate = FinishDate;
                NewCourse.CourseName = CourseName;
            }

            //Close the connection between the MySQL Database, schooldb and the WebServer
            Conn.Close();

            //return course object

            return NewCourse;
        }
    }
}
