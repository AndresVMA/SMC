using SM.Common.Enums;
using SM.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.DataService.CSV.Tests
{
    public static class TestUtils
    {
        public static Student GenerateTestStudent(string studentName)
        {
            var student = new Student()
            {
                Name = studentName,
                SchoolType = SchoolType.High,
                Gender = GenderType.Male,
                LastModifiedDate = DateTime.Now
            };
            return student;
        }
    }
}
