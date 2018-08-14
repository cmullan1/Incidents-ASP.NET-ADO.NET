/*
 *  CPRG 214 Lab 3
 *  Author:  Corinne Mullan
 *  Date:    July 23, 2018
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CPGR214Lab3.App_Code
{
    [DataObject(true)]
    public static class TechnicianDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]

        // The GetAllTechnicians() method returns the TechID and Name for all of the 
        // technicians in the Technicians table.
        public static List<Technician> GetAllTechnicians()
        {
            List<Technician> technicians = new List<Technician>();  // An empty list for the technicians
            Technician tech;                                        // For reading
            
            // Create the connection
            SqlConnection connection = TechSupportDB.GetConnection();

            // Create the select command
            string selectString = "SELECT TechID, Name FROM Technicians " +
                                  "ORDER BY Name";

            SqlCommand selectCommand = new SqlCommand(selectString, connection);

            try
            {
                // Open the connection
                connection.Open();
                // Run the select command and process the results, adding technicians to the list
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())// process next row
                {
                    tech = new Technician();

                    tech.TechID = Convert.ToInt32(reader["TechID"]);
                    tech.Name = reader["Name"].ToString();

                    technicians.Add(tech);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;               // Throw any exceptions for the form to handle
            }
            finally
            {
                connection.Close();
            }

            return technicians;
        }
    }
}