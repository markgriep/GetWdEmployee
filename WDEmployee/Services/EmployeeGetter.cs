using System.Text;
using System.Xml.Serialization;
using WDEmployee.Models;



namespace WDEmployee.Services
{
    public static class EmployeeGetter
    {



        public static string GetFamilyXml()
        {
            StringBuilder sb = new();
            sb.Append(
                "<Report_Data>\r\n    <Report_Entry>\r\n        <EmployeeName>Smith, John</EmployeeName>\r\n        <EmployeeID>123456</EmployeeID>\r\n        <DateOfBirth>1980-03-15-07:00</DateOfBirth>\r\n        <Family>\r\n            <Dependent Descriptor=\"Emma\">\r\n            </Dependent>\r\n            <BirthDate>2010-06-12-07:00</BirthDate>\r\n        </Family>\r\n        <Family>\r\n            <Dependent Descriptor=\"Liam\">\r\n            </Dependent>\r\n            <BirthDate>2013-11-20-07:00</BirthDate>\r\n        </Family>\r\n    </Report_Entry>\r\n    <Report_Entry>\r\n        <EmployeeName>Garcia, Maria</EmployeeName>\r\n        <EmployeeID>789012</EmployeeID>\r\n        <DateOfBirth>1975-08-22-07:00</DateOfBirth>\r\n        <Family>\r\n            <Dependent Descriptor=\"Sofia\">\r\n            </Dependent>\r\n            <BirthDate>2005-04-30-07:00</BirthDate>\r\n        </Family>\r\n        <Family>\r\n            <Dependent Descriptor=\"Carlos\">\r\n            </Dependent>\r\n            <BirthDate>2008-09-17-07:00</BirthDate>\r\n        </Family>\r\n        <Family>\r\n            <Dependent Descriptor=\"Isabella\">\r\n            </Dependent>\r\n            <BirthDate>2012-12-05-07:00</BirthDate>\r\n        </Family>\r\n        <Family>\r\n            <Dependent Descriptor=\"Juan\">\r\n            </Dependent>\r\n            <BirthDate>2016-01-25-07:00</BirthDate>\r\n        </Family>\r\n    </Report_Entry>\r\n    <Report_Entry>\r\n        <EmployeeName>Chen, Wei</EmployeeName>\r\n        <EmployeeID>345678</EmployeeID>\r\n        <DateOfBirth>1990-11-10-07:00</DateOfBirth>\r\n        <Family>\r\n            <Dependent Descriptor=\"Lily\">\r\n            </Dependent>\r\n            <BirthDate>2018-07-08-07:00</BirthDate>\r\n        </Family>\r\n        <Family>\r\n            <Dependent Descriptor=\"Ethan\">\r\n            </Dependent>\r\n            <BirthDate>2020-03-14-07:00</BirthDate>\r\n        </Family>\r\n        <Family>\r\n            <Dependent Descriptor=\"Mia\">\r\n            </Dependent>\r\n            <BirthDate>2022-10-22-07:00</BirthDate>\r\n        </Family>\r\n        <Family>\r\n            <Dependent Descriptor=\"Noah\">\r\n            </Dependent>\r\n            <BirthDate>2024-02-19-07:00</BirthDate>\r\n        </Family>\r\n        <Family>\r\n            <Dependent Descriptor=\"Zoe\">\r\n            </Dependent>\r\n            <BirthDate>2025-01-05-07:00</BirthDate>\r\n        </Family>\r\n    </Report_Entry>\r\n</Report_Data>"
                );
            return sb.ToString();


        }



        public static  void DeserializeFamilyXml(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ReportData));

            using (TextReader reader = new StringReader(xml))
            {
                ReportData result = (ReportData)serializer.Deserialize(reader);

                var thelist = result.ReportEntries;

                foreach (var item in thelist)
                {
                    Console.WriteLine(item.EmployeeName);

                    foreach (var xx in item.Family)
                    {
                        Console.WriteLine($"     {xx.Dependent.Descriptor}");
                    }

                }



                Console.WriteLine(result.ReportEntries.Count());

            }

        }



    }
}
