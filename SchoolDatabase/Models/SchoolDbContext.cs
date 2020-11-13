using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;

namespace SchoolDatabase.Models
{
    public class SchoolDbContext
    {
        //read-only "secret" properties.
        //Only SchoolDbContext class can use them.

        private static string User { get { return "root";  } } 
        private static string Password { get { return "root"; } }
        private static string Database { get { return "schooldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }
        /// <summary>
        /// Return a connection to the database.
        /// </summary>
        /// <example>
        /// private SchoolDbContext SchoolDatabase = new SchoolDbContext();
        /// MySqlConnection Conn = SchoolDatabase.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        { 
            //Instantiating the MySqlConnection Class to create an Oobject
            //Object is a specific connection to our blog database on port 3306 of localhost
            return new MySqlConnection(ConnectionString);
        }
    }
}