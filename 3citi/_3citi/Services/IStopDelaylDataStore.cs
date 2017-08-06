using System.Collections.Generic;
using System.Threading.Tasks;

namespace _3citi.Services
{
    public interface IStopDelayDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(int route, bool forceRefresh = false);

        Task InitializeAsync(int route);

        void Clear();

    }
}