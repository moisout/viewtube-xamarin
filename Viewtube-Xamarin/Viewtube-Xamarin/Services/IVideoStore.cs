using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viewtube_Xamarin.Services
{
    public interface IVideoStore<T>
    {
        Task<T> GetItemAsync(string videoId, bool forceRefresh = false);
    }
}
