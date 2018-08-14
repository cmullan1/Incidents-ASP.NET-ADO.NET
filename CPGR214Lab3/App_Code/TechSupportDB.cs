/*
 *  CPRG 214 Lab 3
 *  Author:  Corinne Mullan
 *  Date:    July 23, 2018
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPGR214Lab3.App_Code
{
    public static class TechSupportDB
    {
        // The GetConnection() method returns a SqlConnecton to the TechSupport database.
        // The connection string is defined in the Web.config file.
        public static SqlConnection GetConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["TechSupportConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}