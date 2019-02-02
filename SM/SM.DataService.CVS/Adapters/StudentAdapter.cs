using SM.Common.Interfaces;
using SM.Common.Models;
using SM.Common;
using System;
using System.Collections.Generic;
using SM.Common.Enums;

namespace SM.DataService.CSV.Adapters
{
    public class StudentAdapter : IModelAdapter<Student>
    {
        public ICollection<Student> GetModels(dynamic modelData)
        {
            string[] studentsRawData = (string[])modelData;
            var students = new List<Student>();
            foreach (var item in studentsRawData)
            {
                var studentRaw = item.Split(',');
                var schoolType = studentRaw[0];
                var gender = studentRaw[2];
                var timestamp = studentRaw[3];
                students.Add(new Student()
                {
                    Name = studentRaw[1],
                    SchoolType = schoolType.ToEnum<SchoolType>(),
                    Gender = gender.ToGender(),
                    LastModifiedDate = DateTime.ParseExact(timestamp, "yyyyMMddHHmmss", null)
                });
            }

            return students;
        }
    }
}
