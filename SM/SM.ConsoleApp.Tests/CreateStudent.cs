using SM.Common.Enums;
using SM.Common.Models;
using SM.DataService.CVS;
using System;
using Xunit;

namespace SM.DataService.CSV.Tests
{
    public class CreateStudent : BaseCsvTest
    {
        [Fact]
        public async void When_Valid_Info_Is_Entered_Then_Student_Should_Be_Created_Sucessfully()
        {
            var student = TestUtils.GenerateTestStudent("obiwan");
            var csvPath = CreateTestFile("CreateSuccess.csv");
            var service = new CSVDataService<Student>(csvPath);
            var result = await service.CreateAsync(student);
            Assert.True(result);
            var retrieveRecord = await service.GetAsync(1);
            Assert.NotNull(retrieveRecord);
            Assert.Equal(student.Name, retrieveRecord.Name);
            Assert.Equal(student.Gender, retrieveRecord.Gender);
            Assert.Equal(student.SchoolType, retrieveRecord.SchoolType);
            Assert.NotEqual(DateTime.MinValue, retrieveRecord.LastModifiedDate);
        }
    }
}
