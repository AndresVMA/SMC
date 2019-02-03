using SM.Common.Enums;
using SM.Common.Interfaces;
using SM.Common.Models;

namespace SM.DataService.CSV
{
    public static class ModelsExtensions
    {
        /// <summary>
        /// Converts the <see cref="IModel"/> properties as a valid csv line.
        /// </summary>
        /// <returns>The record parsed as CSV format.</returns>
        public static string ToCsv(this IModel model)
        { 
            if (model is Student student)
            {
                var schoolType = student.SchoolType.ToString();
                var gender = student.Gender == GenderType.Female ? 'F' : 'M';
                var timestamp = student.LastModifiedDate.ToString("yyyyMMddHHmmss");
                return $"{schoolType},{student.Name},{gender},{timestamp}";
            }
            return string.Empty;
        }
    }
}
