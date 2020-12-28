using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FileSearch.Model
{
    public interface ISearcher<T>
    {
        Task<List<string>> FileSearcher(string targetDirectory, string pattern, CancellationToken cancellationToken, SemaphoreSlim semaphore);

    }

    public class RecursiveSearch : ISearcher<RecursiveSearch>
    {
        public event EventHandler<FileAddedEventArgs> FileAdded;

        public event EventHandler<FileCounterEventArgs> CountersIncreased;

        private Counter _counter = new Counter();

        public async Task<List<string>> FileSearcher(string targetDirectory, string pattern, CancellationToken cancellationToken, SemaphoreSlim semaphore)
        {
            List<string> files = new List<string>();

            foreach (string file in Directory.EnumerateFiles(targetDirectory, "*", SearchOption.AllDirectories))
            {
                try
                {
                    await semaphore.WaitAsync(cancellationToken);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    var fileName = file.Substring(file.LastIndexOf(@"\") + 1);

                    if (Regex.IsMatch(fileName, pattern))
                    {
                        files.Add(file);

                        _counter.IncrementFoundFilesCounter();

                        await OnFileAdded(new FileAddedEventArgs(file));
                    }

                    _counter.IncrementTotalFilesCounter();

                    await OnCounterIncreased(new FileCounterEventArgs(_counter));

                    //await Task.Delay(50);
                }
                finally
                {
                    semaphore.Release();
                }
            }

            return files;   
        }


        private Task OnFileAdded(FileAddedEventArgs args)
        {
            if (FileAdded != null)
            {
                FileAdded(this, args);
            }

            return Task.CompletedTask;
        }

        private Task OnCounterIncreased(FileCounterEventArgs args)
        {
            if (CountersIncreased != null)
            {
                CountersIncreased(this, args);
            }

            return Task.CompletedTask;
        }
    }

    public class FileAddedEventArgs : EventArgs
    {
        public FileAddedEventArgs (string filename)
        {
            FileName = filename;
        }

        public string FileName { get; private set; }
    }

    public class FileCounterEventArgs : EventArgs
    {
        public FileCounterEventArgs(Counter counter)
        {
            Counter = counter;
        }

        public Counter Counter { get; }
    }
}
