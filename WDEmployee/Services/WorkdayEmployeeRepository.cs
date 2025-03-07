
using System.Net.Http.Json;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Diagnostics;
using WDEmployee.Models;
using System.Text;
using System.Reflection.Emit;
using System;



namespace WDEmployee.Services
{
    public class WorkdayEmployeeRepository //: IWorkdayEmployeeRepository
    {



        public string GetEmployeeXmlFromEmbeddedString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(
                @"<wd:Report_Data xmlns:wd=""urn:com.workday.report/RandomDrugTestSelectionPool"">
                      <wd:Report_Entry>
                        <wd:EmployeeName>Terrance, Terry T.</wd:EmployeeName>
                        <wd:EmployeeID>44440751</wd:EmployeeID>
                        <wd:Department>350</wd:Department>
                        <wd:JobCode>104</wd:JobCode>
                        <wd:JobTitle>Supervisor - Water Construction</wd:JobTitle>
                        <wd:DateOfBirth>1988-01-03-08:00</wd:DateOfBirth>
                        <wd:Licenses>
                          <wd:LicenseType wd:Descriptor=""CDL - Class A"">
                            <wd:ID wd:type=""WID"">ca4760002</wd:ID>
                            <wd:ID wd:type=""License_ID_Type_ID"">CDL_Class_A</wd:ID>
                          </wd:LicenseType>
                          <wd:IssuedDate>2022-11-29-08:00</wd:IssuedDate>
                          <wd:ExpirationDate>2029-01-03-08:00</wd:ExpirationDate>
                        </wd:Licenses>
                        <wd:Licenses>
                          <wd:LicenseType wd:Descriptor=""Endorsement - Passenger"">
                            <wd:ID wd:type=""WID"">ca0e10000</wd:ID>
                            <wd:ID wd:type=""License_ID_Type_ID"">Endorsement_Passenger</wd:ID>
                          </wd:LicenseType>
                          <wd:IssuedDate>2022-11-29-08:00</wd:IssuedDate>
                          <wd:ExpirationDate>2029-01-03-08:00</wd:ExpirationDate>
                        </wd:Licenses>
                        <wd:Licenses>
                          <wd:LicenseType wd:Descriptor=""Endorsement - Tanker"">
                            <wd:ID wd:type=""WID"">ca40e10001</wd:ID>
                            <wd:ID wd:type=""License_ID_Type_ID"">Endorsement_Tanker</wd:ID>
                          </wd:LicenseType>
                          <wd:IssuedDate>2022-11-29-08:00</wd:IssuedDate>
                          <wd:ExpirationDate>2029-01-03-08:00</wd:ExpirationDate>
                        </wd:Licenses>
                      </wd:Report_Entry>
                      <wd:Report_Entry>
                        <wd:EmployeeName>Dawson, David D.</wd:EmployeeName>
                        <wd:EmployeeID>44441219</wd:EmployeeID>
                        <wd:Department>080</wd:Department>
                        <wd:JobCode>1111</wd:JobCode>
                        <wd:JobTitle>Senior Customer Operations Spec</wd:JobTitle>
                        <wd:DateOfBirth>1988-10-15-07:00</wd:DateOfBirth>
                      </wd:Report_Entry>
                </wd:Report_Data>"
            );
            return sb.ToString();
        }





        public async Task<IEnumerable<WorkdayEmployee>> GetWorkdayEmployeesFromApiAsync(string _base64Credentials, string _peopleUrl)
        {
            HttpClientManager _httpClientMgr = new();
            HttpResponseMessage response = await _httpClientMgr.GetApiResponseAsync(_peopleUrl,  _base64Credentials);


            if (response.IsSuccessStatusCode)
            {
                var XmlResponse = await response.Content.ReadAsStringAsync();
                return DeserializeWorkdayEmployees(XmlResponse);                            // Send back the result
            }
            return Enumerable.Empty<WorkdayEmployee>();                                     // Return an empty list if the API call fails
        }






        /// <summary>
        /// DESERIALIZE XML into Employees list. PRIVATE, only for in this class
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        public IEnumerable<WorkdayEmployee> DeserializeWorkdayEmployees(string xmlContent)
        {
            var serializer = new XmlSerializer(typeof(WorkdayEmployeeReport));                  // set a seralizer

            try
            {
                using (var reader = new StringReader(xmlContent))                               // read the content into a string reader
                {
                    var result = serializer.Deserialize(reader) as WorkdayEmployeeReport;       // call the deseralizer as a "report"
                    return result?.Employees ?? new List<WorkdayEmployee>();                    // Split out the Employees part of the report and return it
                }
            }
            catch (InvalidOperationException ex)
            {
                throw;
            }
        }





    }
}
