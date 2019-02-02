using SM.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SM.DataService.CVS
{
    public class CSVDataService<T> : IDataService<T> where T: class, IModel
    {
        const string studentStore = "Students.csv";  
        public async Task<bool> CreateAsync(T record)
        {
            record.LastModifiedDate = DateTime.Now;
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}{studentStore}";
            try
            {
                await File.AppendAllLinesAsync(path, new List<string> { record.ToString() });
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid recordId)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(Guid recordId)
        {
            throw new NotImplementedException();
        }
    }
}
