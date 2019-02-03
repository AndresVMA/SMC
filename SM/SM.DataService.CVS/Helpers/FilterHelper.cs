using SM.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM.DataService.CSV.Helpers
{
    public static class FilterHelper
    {
        public static IEnumerable<Student> FilterStudents(IEnumerable<Student> studentList, IEnumerable<string> searchArguments)
        {
            IEnumerable<Student> filterResult = studentList;
            foreach (var filter in searchArguments)
            {
                var equalSignIndex = filter.IndexOf("=");
                var property = filter.Substring(0, equalSignIndex);
                var filterValue = filter.Substring(equalSignIndex + 1);
                filterResult = FilterByProperty(filterResult, property, filterValue);
            }

            return filterResult;
        }

        private static IEnumerable<Student> FilterByProperty(
            IEnumerable<Student> studentList,
            string propertyName,
            string propertyValue)
        {
            IEnumerable<Student> filterResult = studentList;
            Func<Student, bool> predicate = null;
            Func<Student, object> orderPredicate = null;
            switch (propertyName)
            {
                case "type":
                    predicate = s => s.SchoolType.ToString()
                        .Equals(propertyValue, StringComparison.InvariantCultureIgnoreCase);
                    orderPredicate = s => s.LastModifiedDate;
                    break;
                case "name":
                    predicate = s => s.Name.ToString()
                        .StartsWith(propertyValue, StringComparison.InvariantCultureIgnoreCase);
                    orderPredicate = s => s.Name;
                    break;
                case "gender":
                    predicate = s => s.Gender.ToString()
                        .Equals(propertyValue, StringComparison.InvariantCultureIgnoreCase);
                    orderPredicate = s => s.LastModifiedDate;
                    break;
                default:
                    break;
            }
            if (predicate != null)
            {
                filterResult = studentList.Where(predicate).Select(s => s).OrderBy(orderPredicate);
            }
            return filterResult;
        }
    }
}
