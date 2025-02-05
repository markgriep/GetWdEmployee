
using System.Net.Http.Json;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Diagnostics;
using WDEmployee.Models;



namespace WDEmployee.Services
{
    public class WorkdayEmployeeRepository //: IWorkdayEmployeeRepository
    {



        public async Task<IEnumerable<WorkdayEmployee>> GetWorkdayEmployeesFromApiAsync(string _base64Credentials, string _peopleUrl)
        {

            HttpClientManager _httpClientMgr = new();


            HttpResponseMessage response = await
           _httpClientMgr.GetApiResponseAsync(
              _peopleUrl,
              _base64Credentials
              );




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
        private IEnumerable<WorkdayEmployee> DeserializeWorkdayEmployees(string xmlContent)
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
