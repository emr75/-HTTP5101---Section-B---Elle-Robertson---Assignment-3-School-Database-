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

        //The database context class which allows us to access our mySQL Database.
        private SchoolDbContext SchoolDatabase = new SchoolDbContext();

        //This controller will access the "classes" table of the schooldb database
        /// <summary>
        /// Returns a list of classes in the system
        /// classes in reference to database will be refered to as courses in future when possible
        /// </summary>
        /// <example>GET api/CourseData/ListCourses</example>
        /// <returns>
        /// A list of course information including classid
        /// </returns>
        [HttpGet]

        public IEnumerable<Course> ListCourses()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDatabase.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Courses' names
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

                Course NewCourse = new Course();
                NewCourse.CourseId = CourseId;
                NewCourse.CourseCode = CourseCode;
                NewCourse.TeachId = TeachId;
                NewCourse.StartDate = StartDate;
                NewCourse.FinishDate = FinishDate;
                NewCourse.CourseName = CourseName;

                //Add the course Name to the List
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

                NewCourse.CourseId = CourseId;
                NewCourse.CourseCode = CourseCode;
                NewCourse.TeachId = TeachId;
                NewCourse.StartDate = StartDate;
                NewCourse.FinishDate = FinishDate;
                NewCourse.CourseName = CourseName;
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            return NewCourse;
        }
    }
}
