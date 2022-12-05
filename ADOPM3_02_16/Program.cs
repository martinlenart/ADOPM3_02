using System;

namespace ADOPM3_02_16
{
    class Program
    {
        //Delegate Type
        delegate string AlarmResponse(int priority);

        static void Main(string[] args)
        {
            AlarmResponse CompanyResponse = AlarmResponseCompany1;  // Create delegate object - shorthand
            string response = CompanyResponse(1); // Invoke delegate - shorthand

            //string response = CompanyResponse.Invoke(1); // Invoke delegate - longhand

            Console.WriteLine(response);

            
            Console.WriteLine();
            string r = null;
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    //r = AlarmResponseCompany1(3);
                    CompanyResponse = AlarmResponseCompany1;
                else
                    //r = AlarmResponseCompany2(3);
                    CompanyResponse = AlarmResponseCompany2;

                //

                r = ComplexResponse(CompanyResponse);
            }

        }

        private static string ComplexResponse(AlarmResponse CompanyResponse)
        {
            //complex algorithm, text ringa SOS Alarm
            string r = CompanyResponse(3);
            Console.WriteLine(r);
            return r;
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
        static string AlarmResponseCompany2(int priority) =>
        (priority) switch
        {
            1 => "Company2 Critical Level",
            2 => "Company2 Moderate Level",
            3 => "Company2 Easy Level",
            _ => "Comapny2 Unknown Level"
        };
    }
}
