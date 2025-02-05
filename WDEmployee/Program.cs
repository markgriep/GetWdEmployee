using WDEmployee.Services;

namespace WDEmployee
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            // Test to see if you get secrets
            Console.WriteLine(SecretsManager.GetSecret("test"));


            // Now get the real info.
            var _creds = SecretsManager.GetBase64CredentialsFromSecrets("wdusername", "wdpassword");
            var _peopleUrl = SecretsManager.GetSecret("peopleuri");


            WorkdayEmployeeRepository _wdRepository = new();            // spin up a new repository

            var _employeeList = await _wdRepository.GetWorkdayEmployeesFromApiAsync(_creds,_peopleUrl);  // Get the goods.


            // Validate. Loop through each employee
            foreach (var item in _employeeList.ToList())
            {
                Console.WriteLine(item.EmployeeName);
            }


            Console.ReadKey();

        }
    }
}
