using System;
using InADifferentFile;

namespace InADifferentFile
{
        //Delegate Type
        delegate void AlarmResponse(int priority); //We move the Delegate Type outside our code
}

namespace ADOPM3_02_17
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmResponse CompanyResponse = AlarmResponseCompany1;  // Create and assign delegate object - shorthand
            CompanyResponse += AlarmResponseCompany2; // Assign another delegate for multicast
            CompanyResponse += AlarmResponseCompany3; // Assign yet another delegate for multicast
            
            CompanyResponse(1); // Invoke delegate - shorthand, Multicast 3 delegates

            Console.WriteLine();
            CompanyResponse -= AlarmResponseCompany2; // Remove one particular delegate
            CompanyResponse(1); // Invoke delegate - shorthand, Multicast 2 delegates
            
        }

        //The functions that execution is delegated to
        static void AlarmResponseCompany1(int priority)
        {
            Console.WriteLine(theResponse("Company1", priority));    
        }
        static void AlarmResponseCompany2(int priority)
        {
            Console.WriteLine(theResponse("Company2", priority));
        }
        static void AlarmResponseCompany3(int priority)
        {
            Console.WriteLine(theResponse("Company3", priority));
        }
        static string theResponse(string Company, int priority) =>
            (priority) switch
            {
                1 => $"{Company} Critical Level",
                2 => $"{Company} Moderate Level",
                3 => $"{Company} Easy Level",
                _ => $"{Company} Unknown Level"
            };
    }

    //Exercises:
    //1.    Create your own multicast delegate having your own class type as parameter in your delegate type
    //2.    Create your own multicast delegate with a tuple as response type. What happens with the response in multicast?
    //3.    Change the delegate to singlecast. What happens to the response?
}
