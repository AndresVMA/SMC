using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SM.ConsoleApp
{
    internal static class InputManager
    {
        internal static string GetValidStringEntry(string objectName, string propertyName, int minimunLength = 2)
        {
            Console.Write($"Enter the {objectName} {propertyName}: ");
            var response = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(response) || response.Length < minimunLength)
            {
                Console.WriteLine($"Value cannot be empty or less than {minimunLength} characters, please try again.");
                Console.Write($"Enter the {objectName} {propertyName}: ");
                response = Console.ReadLine();
            }
            return response;
        }

        internal static char GetValidCharEntry(string genderMessage, List<char> validGenderTypes)
        {
            Console.Write(genderMessage);
            var response = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(response)
                || (response.Length > 1)
                || !validGenderTypes.Contains(response[0]))
            {
                Console.WriteLine($"Invalid value, Please try again.");
                Console.Write(genderMessage);
                response = Console.ReadLine();
            }
            return response[0];
        }

        internal static string GetValidSearchCriteria(string promptMessage)
        {
            Console.Write(promptMessage);
            var regex = new Regex(@"([a-zA-Z]*=\w*)*");
            var response = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(response)
                || !regex.IsMatch(response))
            {
                Console.WriteLine($"Invalid criteria, Please try again.");
                Console.Write(promptMessage);
                response = Console.ReadLine();
            }
            return response;
        }
    }
}
