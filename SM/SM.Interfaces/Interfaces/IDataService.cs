using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SM.Common.Interfaces
{
    /// <summary>
    /// Defines a data service to DML operations.
    /// </summary>
    /// <typeparam name="T">The record type.</typeparam>
    public interface IDataService<T> where T: class, IModel
    {
        /// <summary>
        /// Get all records for the given type.
        /// </summary>
        /// <returns>A collection of all records from the store.</returns>
        Task<ICollection<T>> GetAllAsync();

        /// <summary>
        /// Gets a record from the store.
        /// </summary>
        /// <param name="recordId">The identifier of the record to get.</param>
        /// <returns>The record found.</returns>
        Task<T> GetAsync(int recordId);

        /// <summary>
        /// Creates a record on the store.
        /// </summary>
        /// <param name="record">The record to be created </param>
        /// <returns>A value indicating whether or not the record was created.</returns>
        Task<bool> CreateAsync(T record);

        /// <summary>
        /// Deletes a record given an Id.
        /// </summary>
        /// <param name="recordId">The id of the record to delete.</param>
        /// <returns>A value indicating whether or not the record was deleted.</returns>
        Task<bool> DeleteAsync(int recordId);
    }
}
