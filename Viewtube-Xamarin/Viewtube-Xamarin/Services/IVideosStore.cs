using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viewtube_Xamarin.Services
{
    public interface IVideosStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
