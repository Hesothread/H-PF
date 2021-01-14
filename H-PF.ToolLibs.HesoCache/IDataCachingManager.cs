using System.Collections.Generic;

namespace H_PF.ToolLibs.HesoCache
{
    public interface IDataCachingManager<T>
    {
        delegate List<T> SortCacheEventHandler(List<T> message);

        List<T> Read();
        List<T> Dequeue();
        void Enqueue(T metricsDto);

        event SortCacheEventHandler SortCache;
    }
}