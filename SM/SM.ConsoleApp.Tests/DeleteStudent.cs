using SM.Common.Models;
using SM.DataService.CVS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SM.DataService.CSV.Tests
{
    public class DeleteStudent : BaseCsvTest
    {
        [Fact]
        public async void When_Valid_Id_Is_Provided_Then_Student_Should_Be_Deleted_Sucessfully()
        {
            var student = TestUtils.GenerateTestStudent("obiwan");
            var csvPath = CreateTestFile("DeleteSuccess.csv");
            var service = new CSVDataService<Student>(csvPath);
            var result = await service.CreateAsync(student);
            Assert.True(result);
            var deleteResult = await service.DeleteAsync(1);
            Assert.True(deleteResult);
            var totalRecords = await service.GetAllAsync();
            Assert.Equal(0, totalRecords.Count);
        }

        [Fact]
        public async void When_Invalid_Id_Is_Provided_Then_Student_Should_NotBe_Deleted()
        {
            var student = TestUtils.GenerateTestStudent("obiwan");
            var csvPath = CreateTestFile("DeleteFail.csv");
            var service = new CSVDataService<Student>(csvPath);
            var result = await service.CreateAsync(student);
            Assert.True(result);
            var deleteResult = await service.DeleteAsync(2);
            Assert.False(deleteResult);
            var totalRecords = await service.GetAllAsync();
            Assert.Equal(1, totalRecords.Count);
        }
    }
}
