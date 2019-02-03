using SM.Common.Interfaces;
using SM.DataService.CSV;
using SM.DataService.CSV.Adapters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SM.DataService.CVS
{
    /// <summary>
    /// Defines a data service implementation to store/retrieve/delete data from a CSV file.
    /// </summary>
    /// <typeparam name="T">The type of record to operate with.</typeparam>
    public class CSVDataService<T> : IDataService<T> where T: class, IModel
    {
        private const string DefaultStore = "Students.csv";  
        private string _csvPath;
        private IModelAdapter<T> _adapter;
        public CSVDataService(string csvPath)
        {
            _adapter = new CsvAdapter<T>();
            _csvPath = string.IsNullOrWhiteSpace(csvPath) ?
                $"{AppDomain.CurrentDomain.BaseDirectory}{DefaultStore}" : csvPath;
        }

        /// <summary>
        /// Saves a record into a CSV file.
        /// </summary>
        /// <param name="record">The record to save.</param>
        /// <returns>A value indicating whether or not the record was created.</returns>
        public async Task<bool> CreateAsync(T record)
        {
            record.LastModifiedDate = DateTime.Now;
            try
            {
                await File.AppendAllLinesAsync(_csvPath, new List<string> { record.ToCsv() });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes a record from the CSV file.
        /// </summary>
        /// <param name="recordId">The id of the record to delete.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int recordId)
        {
            var allRecords = await GetAllAsync();
            var recordIdExists = allRecords
                .Where(record => record.Id == recordId).Any();
            if (!recordIdExists)
            {
                return false;
            }

            var csvLines = allRecords
                .Where(record => record.Id != recordId)
                .Select(record => record.ToString());
            try
            {
                await File.WriteAllLinesAsync(_csvPath, csvLines);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a record from the CSV based on its Id.
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(int recordId)
        {
            var allRecords = await GetAllAsync();
            return allRecords.Where(record => record.Id == recordId).FirstOrDefault();
        }

        /// <summary>
        /// Gets all records from the CSV file.
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        public async Task<ICollection<T>> GetAllAsync()
        {
            var rawData = await File.ReadAllLinesAsync(_csvPath);
            return _adapter.GetModels(rawData);
        }
    }
}
