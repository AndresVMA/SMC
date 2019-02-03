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
        /// 
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        Task<ICollection<T>> GetAllAsync();

        /// <summary>
        /// Gets a record from the store.
        /// </summary>
        /// <param name="recordId">The identifier of the record to get.</param>
        /// <returns></returns>
        Task<T> GetAsync(int recordId);

        /// <summary>
        /// Creates a record on the store.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(T record);

        /// <summary>
        /// Deletes a record given an Id.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int recordId);
    }
}
