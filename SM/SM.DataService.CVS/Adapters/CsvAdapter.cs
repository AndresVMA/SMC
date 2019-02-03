using SM.Common.Interfaces;
using SM.Common.Models;
using SM.Common;
using System;
using System.Collections.Generic;
using SM.Common.Enums;

namespace SM.DataService.CSV.Adapters
{
    public class CsvAdapter<T> : IModelAdapter<T> where T : class, IModel
    {
        public ICollection<Student> GetStudentModels(dynamic data)
        {
            string[] studentsRawData = (string[])data;
            var students = new List<Student>();
            var virtualStudentId = 1;
            foreach (var item in studentsRawData)
            {
                var studentRaw = item.Split(',');
                var schoolType = studentRaw[0];
                var gender = studentRaw[2];
                var timestamp = studentRaw[3];
                students.Add(new Student()
                {
                    Id = virtualStudentId++,
                    Name = studentRaw[1],
                    SchoolType = schoolType.ToEnum<SchoolType>(),
                    Gender = gender.ToGender(),
                    LastModifiedDate = DateTime.ParseExact(timestamp, "yyyyMMddHHmmss", null)
                });
            }

            return students;
        }
        public ICollection<T> GetModels(dynamic modelData)
        {
            if (typeof(T) == typeof(Student))
            {
                return GetStudentModels(modelData);
            }
            return new List<T>();
        }
    }
}
