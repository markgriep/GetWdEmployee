﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WDEmployee.Models
{


    /// <summary>
    /// This is the ROOT of the XML response from the Workday API. In WorkDay parlance, a "report" object
    /// </summary>
    [XmlRoot(ElementName = "Report_Data", Namespace = "urn:com.workday.report/RandomDrugTestSelectionPool")]
    public class WorkdayEmployeeReport
    {

        /// <summary>
        /// These are the sub elements, individual employees in the report.  a list of WORKDAY EMPLOYEE objects
        /// </summary>
        [XmlElement(ElementName = "Report_Entry", Namespace = "urn:com.workday.report/RandomDrugTestSelectionPool")]
        public List<WorkdayEmployee> Employees { get; set; } = new List<WorkdayEmployee>();

    }




    /// <summary>
    /// One level down from the root.  Multiple EMPLOYEES
    /// </summary>
    public class WorkdayEmployee
    {

        [Key]
        public int Id { get; set; } // Primary Key


        [XmlElement(ElementName = "EmployeeName", Namespace = "urn:com.workday.report/RandomDrugTestSelectionPool")]
        public string EmployeeName { get; set; } = string.Empty;


        [XmlElement(ElementName = "EmployeeID", Namespace = "urn:com.workday.report/RandomDrugTestSelectionPool")]
        public string EmployeeId { get; set; } = string.Empty;      // must be string.  Some ids are like C-123 or A-123


        [XmlElement(ElementName = "Department", Namespace = "urn:com.workday.report/RandomDrugTestSelectionPool")]
        public string Department { get; set; } = string.Empty;

        [XmlElement(ElementName = "JobCode", Namespace = "urn:com.workday.report/RandomDrugTestSelectionPool")]
        public string JobCode { get; set; } = string.Empty;

        [XmlElement(ElementName = "JobTitle", Namespace = "urn:com.workday.report/RandomDrugTestSelectionPool")]
        public string JobTitle { get; set; } = string.Empty;

        [XmlElement(ElementName = "DateOfBirth", Namespace = "urn:com.workday.report/RandomDrugTestSelectionPool")]
        public DateTime DateOfBirth { get; set; }







    }
}




