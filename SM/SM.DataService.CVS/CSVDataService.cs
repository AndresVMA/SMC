using SM.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SM.DataService.CVS
{
    /// <summary>
    /// Defines a data service implementation to store/retrieve/delete data from a CSV file.
    /// </summary>
    /// <typeparam name="T">The type of record to operate with.</typeparam>
    public class CSVDataService<T> : IDataService<T> where T: class, IModel
    {
        const string defaultStore = "Students.csv";  
        private string _csvPath;
        public CSVDataService(string csvPath)
        {
            _csvPath = string.IsNullOrWhiteSpace(csvPath) ?
                $"{AppDomain.CurrentDomain.BaseDirectory}{defaultStore}" : csvPath;
        }

        /// <summary>
        /// Saves a record into the store.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(T record)
        {
            record.LastModifiedDate = DateTime.Now;
            try
            {
                await File.AppendAllLinesAsync(_csvPath, new List<string> { record.ToString() });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes a record
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid recordId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(Guid recordId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public async Task<ICollection<T>> GetAllAsync(IModelAdapter<T> adapter)
        {
            var rawData = await File.ReadAllLinesAsync(_csvPath);
            return adapter.GetModels(rawData);
        }
    }
}
