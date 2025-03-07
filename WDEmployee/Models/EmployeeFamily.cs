using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WDEmployee.Models
{




    [XmlRoot("Report_Data")]
    public class ReportData
    {
        [XmlElement("Report_Entry")]
        public List<ReportEntry> ReportEntries { get; set; }
    }

    public class ReportEntry
    {
        [XmlElement("EmployeeName")]
        public string EmployeeName { get; set; }

        [XmlElement("EmployeeID")]
        public string EmployeeID { get; set; }

        [XmlElement("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [XmlElement("Family")]
        public List<Family> Family { get; set; }
    }

    public class Family
    {
        [XmlElement("Dependent")]
        public Dependent Dependent { get; set; }

        [XmlElement("BirthDate")]
        public DateTime BirthDate { get; set; }
    }

    public class Dependent
    {
        [XmlAttribute("Descriptor")]
        public string Descriptor { get; set; }
    }



}
