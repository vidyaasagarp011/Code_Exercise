using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public async Task<List<string>> InitializeListAsync(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            var tasks = items.Select(async i =>
            {
                var r = await Task.Run(() => i).ConfigureAwait(false);
                bag.Add(r);
            });

            await Task.WhenAll(tasks);
            return bag.ToList();
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();
            var concurrentDictionary = new ConcurrentDictionary<int, string>();

            var partitions = Partitioner.Create(itemsToInitialize).GetPartitions(3);

            var tasks = partitions.Select(partition => Task.Run(() =>
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    {
                        var item = partition.Current;
                        concurrentDictionary.GetOrAdd(item, getItem);
                    }
                }
            }));

            Task.WaitAll(tasks.ToArray());

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}