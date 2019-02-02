using System;

namespace SM.Models
{
    public interface IModel
    {
        Guid Id { get; set; }
        DateTime LastModifiedDate { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
