using System;

namespace ADOPM3_02_16
{
    class Program
    {
        //Delegate Type
        delegate string AlarmResponse(int priority);

        static void Main(string[] args)
        {
            string Greeting = "Hello Operator. Pls take care "; 

            AlarmResponse CompanyResponse = (int priority) =>
             (priority) switch
             {
                 1 => Greeting + "Company1 Critical Level",
                 2 => Greeting + "Company1 Moderate Level",
                 3 => Greeting + "Company1 Easy Level",
                 _ => Greeting + "Comapny1 Unknown Level"
             };

            string response = CompanyResponse(1); // Invoke delegate - shorthand
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
