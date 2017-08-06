using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3citi.Services
{
    public interface ITripDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync( int i, bool forceRefresh = false);

        Task InitializeAsync( int i);

        void Clear();
    }
}