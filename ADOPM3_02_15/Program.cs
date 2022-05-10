using System;

namespace ADOPM3_02_15
{
    class Program
    {
        //Delegate Type
        delegate string AlarmResponse(int priority);

        static void Main(string[] args)
        {
            AlarmResponse CompanyResponse = new AlarmResponse(AlarmResponseCompany1);  // Create delegate object
            string response = CompanyResponse.Invoke(1); // Invoke delegate

            Console.WriteLine(response); //
        }

        //The function that execution is delegated to
        static string AlarmResponseCompany1(int priority) => 
            (priority) switch
            {
                1 => "Company1 Critical Level",
                2 => "Company1 Moderate Level",
                3 => "Company1 Easy Level",
                _ => "Comapny1 Unknown Level"
            };
       
    }
}
