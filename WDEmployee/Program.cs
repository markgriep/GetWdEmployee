using WDEmployee.Services;

namespace WDEmployee
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            GetFamilyStuff();

            //DoWdXmlStuff().Wait();
            DoAlternateWdXmlStuff().Wait();


            Console.ReadKey();
        }






        private static void GetFamilyStuff()
        {
            FamilyGetter.DeserializeFamilyXml(FamilyGetter.GetFamilyXml());
        }





        private static async Task DoAlternateWdXmlStuff()
        {
            WorkdayEmployeeRepository _wdRepository = new();            // spin up a new repository

            var x = _wdRepository.GetEmployeeXmlFromEmbeddedString();

            var y = _wdRepository.DeserializeWorkdayEmployees(x);


            var thelist = y.ToList();



            // Validate. Loop through each employee
            foreach (var item in thelist)
            {
                Console.WriteLine(item.EmployeeName);

                foreach (var xx in item.Licenses)
                {
                    Console.WriteLine($"     {xx.LicenseType.Descriptor}");
                    Console.WriteLine($"     {xx.IssuedDate}");
                    Console.WriteLine($"     {xx.ExpirationDate}");
                }
            }
        }





        private static async Task DoWdXmlStuff()
        {
            // Test to see if you get secrets
            Console.WriteLine(SecretsManager.GetSecret("test"));


            // Now get the real info.
            var _creds = SecretsManager.GetBase64CredentialsFromSecrets("wdusername", "wdpassword");
            var _peopleUrl = SecretsManager.GetSecret("peopleuri");


            WorkdayEmployeeRepository _wdRepository = new();            // spin up a new repository

            var _employeeList = await _wdRepository.GetWorkdayEmployeesFromApiAsync(_creds, _peopleUrl);  // Get the goods.



            var thelist = _employeeList.ToList();

            // Validate. Loop through each employee
            foreach (var item in thelist)
            {
                Console.WriteLine(item.EmployeeName);

                foreach (var xx in item.Licenses)
                {
                    Console.WriteLine($"     {xx.LicenseType.Descriptor}");
                    Console.WriteLine($"     {xx.IssuedDate}");
                    Console.WriteLine($"     {xx.ExpirationDate}");
                }
            }
        }
    }
}
