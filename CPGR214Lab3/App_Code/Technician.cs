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
    // Definition of the Technician entity class
    public class Technician
    {
        // Public accessor properties
        // Only the TechID and Name are required in this lab
        public int TechID { get; set; }

        public string Name { get; set; }

        // Default constructor
        public Technician() { }
    }
}