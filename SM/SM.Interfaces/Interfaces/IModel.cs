using System;

namespace SM.Common.Interfaces
{
    /// <summary>
    /// Defines the contract for all models.
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Gets or sets the model identifier.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the last modified date.
        /// </summary>
        DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        DateTime CreatedDate { get; set; }
    }
}
