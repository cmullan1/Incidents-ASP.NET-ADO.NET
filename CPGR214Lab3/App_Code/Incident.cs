/*
 *  CPRG 214 Lab 3
 *  Author:  Corinne Mullan
 *  Date:    July 23, 2018
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPGR214Lab3.App_Code
{
    // Definition of the Incident entity class
    public class Incident
    {
        // Public accessor properties
        public int IncidentID { get; set; }

        public string Name { get; set; }        // The customer name associated with the incident and
                                                // obtained from the Customers table

        public string ProductCode { get; set; }

        public DateTime DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }   // Use a nullable type for the DateClosed.  All 
                                                    // other fields will have values

        public String Title { get; set; }

        public String Description { get; set; }

        // Default constructor
        public Incident() { }
    }
}