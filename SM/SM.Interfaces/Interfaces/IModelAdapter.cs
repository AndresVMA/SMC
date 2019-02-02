using System.Collections.Generic;

namespace SM.Common.Interfaces
{
    public interface IModelAdapter<T> where T : class, IModel
    {
        ICollection<T> GetModels(dynamic modelData);
    }
}
