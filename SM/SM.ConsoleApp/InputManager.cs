using System;
using System.Collections.Generic;

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
    }
}
