using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace H_PF.ToolLibs.HesoCache
{
    public class DataCachingManager<T> : IDataCachingManager<T>
    {
        private FileInfo cacheFileInfo;
        private int minFileSize = 100;
        private static readonly object lockCacheFile = new object();
        private int? range;

        public event IDataCachingManager<T>.SortCacheEventHandler SortCache;

        private bool DataAvailable => File.Exists(cacheFileInfo.FullName);


        public DataCachingManager(IOptions<FileCacheSettings> settings)
        {
            this.cacheFileInfo = new FileInfo($"{Environment.CurrentDirectory}\\Cache\\{typeof(T).Name}.json");
            this.range = settings.Value.Range;
        }

        public void Enqueue(T metricsDto)
        {
            if (metricsDto == null)
                return;
            lock (lockCacheFile)
            {
                if (!Directory.Exists(cacheFileInfo.DirectoryName))
                    Directory.CreateDirectory(cacheFileInfo.DirectoryName);

                var jsonData = cacheFileInfo.Exists ? File.ReadAllText(cacheFileInfo.FullName) : null;
                var metrics = string.IsNullOrWhiteSpace(jsonData) ? new List<T>() : JsonConvert.DeserializeObject<List<T>>(jsonData);
                if (metrics == null)
                    metrics = new List<T>();
                metrics.Add(metricsDto);
                var sortedMetrics = SortCache != null ? SortCache.Invoke(metrics) : metrics;
                jsonData = JsonConvert.SerializeObject(sortedMetrics, Formatting.Indented);

                File.WriteAllText(cacheFileInfo.FullName, jsonData);
            }
        }

        public List<T> Dequeue()
        {
            if (!DataAvailable)
                return null;

            List<T> data = null;

            lock (lockCacheFile)
            {
                try
                {
                    var content = File.ReadAllText(cacheFileInfo.FullName);
                    var jArray = JArray.Parse(content);

                    var elements = jArray.Children().Take(this.range ?? int.MaxValue);
                    data = elements.Select(x => x.ToObject<T>()).ToList();

                    jArray.Children().Take(range ?? int.MaxValue).ToList().ForEach(x => jArray.Remove(x));
                    File.WriteAllText(cacheFileInfo.FullName, jArray.ToString());
                }
                catch (Exception ex)
                {
                    data = null;
                }
            }

            return data;
        }

        public List<T> Read()
        {
            if (!DataAvailable)
                return null;

            List<T> data = null;

            lock (lockCacheFile)
            {
                try
                {
                    var content = File.ReadAllText(cacheFileInfo.FullName);
                    var jArray = JArray.Parse(content);

                    var elements = jArray.Children().Take(this.range ?? int.MaxValue);
                    data = elements.Select(x => x.ToObject<T>()).ToList();
                }
                catch (Exception ex)
                {
                    data = null;
                }
            }

            return data;
        }
    }
}
