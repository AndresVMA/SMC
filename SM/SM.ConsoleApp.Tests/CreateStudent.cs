using SM.Common.Enums;
using SM.Common.Models;
using System;
using Xunit;

namespace SM.ConsoleApp.Tests
{
    public class CreateStudent
    {
        [Fact]
        public void When_Valid_Info_Is_Entered_Then_Student_Should_Be_Created_Sucessfully()
        {
            var student = new Student()
            {
                Name = "Obiwan",
                Type = SchoolType.High,
                Gender = GenderType.Male,
                LastModifiedDate = DateTime.Now
            };

             
        }
    }
}
