using SM.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace SM.DataService.CVS
{
    public class CVSDataService<T> : IDataService<T> where T: class, IModel
    {
        public async Task<bool> CreateAsync(T record)
        {
            throw new NotImplementedException();
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
