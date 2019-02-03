using System.Collections.Generic;

namespace SM.Common.Interfaces
{
    /// <summary>
    /// Defines the model adapter contract.
    /// </summary>
    /// <typeparam name="T">The model type output.</typeparam>
    public interface IModelAdapter<T> where T : class, IModel
    {
        /// <summary>
        /// Generates a collection of <see cref="T"/> models for the given data.
        /// </summary>
        /// <param name="modelData">The original data to be converted to the given type.</param>
        /// <returns>A collection with all the records converted to the given type.</returns>
        ICollection<T> GetModels(dynamic modelData);
    }
}
