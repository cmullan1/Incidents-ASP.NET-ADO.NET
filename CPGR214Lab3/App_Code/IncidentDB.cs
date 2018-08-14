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
    public static class IncidentDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]

        // The GetOpenTechIncidents() method returns all of the open incidents (i.e., 
        // DateClosed is null) from the Incidents table for a particular technician.  
        // An inner join is performed to obtain the customer name from the CustomerID.
        public static List<Incident> GetOpenTechIncidents(int techID)
        {
            Incident incident = null;                           // For reading
            List<Incident> incidents = new List<Incident>();    // Empty list

            // Get a connection to the database
            SqlConnection connection = TechSupportDB.GetConnection();

            // Define the SQL select statement.  Do an inner join with the Customers table
            // to obtain the customer name for displaying.
            string selectQuery = "SELECT IncidentID, Name, ProductCode,  " +
                                        "DateOpened, DateClosed, Title, Description " +
                                 "FROM Incidents i " +
                                 "INNER JOIN Customers c ON c.CustomerID = i.CustomerID " +
                                 "WHERE TechID = @TechID " + 
                                 "AND DateClosed IS NULL " + 
                                 "ORDER BY DateOpened";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@TechID", techID);

            try
            {
                // Open the connection
                connection.Open();

                // Execute the query.  Multiple records may be returned.
                SqlDataReader reader = selectCommand.ExecuteReader();   

                // Loop through the query results
                while (reader.Read()) 
                {
                    incident = new Incident();

                    incident.IncidentID = Convert.ToInt32(reader["IncidentID"]);
                    incident.Name = reader["Name"].ToString();
                    incident.ProductCode = reader["ProductCode"].ToString();
                    incident.DateOpened = (DateTime)reader["DateOpened"];
                    incident.DateClosed = reader["DateClosed"] as DateTime?;
                    incident.Title = reader["Title"].ToString();
                    incident.Description = reader["Description"].ToString();
                  
                    incidents.Add(incident);
                }
            }
            catch (Exception ex)
            {
                // Throw any exceptions for the form to handle
                throw ex;           
            }
            finally
            {
                // Close the database connection
                connection.Close(); 
            }

            return incidents;
        }
    }
}