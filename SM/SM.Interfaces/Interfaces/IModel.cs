using System;

namespace SM.Common.Interfaces
{
    public interface IModel
    {
        int Id { get; set; }
        DateTime LastModifiedDate { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
