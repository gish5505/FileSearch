using FileSearch.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearch
{
    public partial class Window
    {
        public delegate void FunctionDelegate(string filename);

        public delegate void CounterDelegate(Counter counter);

        private CancellationTokenSource _cancellationTokenSource;

        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        private bool _isRunning = false;

        private FileSearchTimer timer = new FileSearchTimer();

        private void startButton_Click(object sender, EventArgs e)
        {            
            if (!_isRunning)
            {
                _isRunning = !_isRunning;
                startButton.Text = "Стоп";
                fileTreeView.Nodes.Clear();
                pauseButton.Enabled = true;
                //startButton.Enabled = false;

                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Dispose();
                    _cancellationTokenSource = null;
                }

                _cancellationTokenSource = new CancellationTokenSource();

                var pattern = targetFileInput.Text;
                var startDirectory = targetDirectoryInput.Text;
                SavePathAndPattern();   

                var searcher = new RecursiveSearch();

                searcher.FileAdded += (s, arg) =>
                {
                    try
                    {
                        statusStripLabel.Text = arg.FileName;

                        fileTreeView.BeginInvoke(new FunctionDelegate(AddNode), arg.FileName);

                    }
                    catch (Exception err)
                    {
                        Debug.WriteLine(err.Message);
                    }

                };

                searcher.CountersIncreased += (s, arg) =>
                {
                    try
                    {
                        totalFilesLabel.BeginInvoke(new CounterDelegate(SetTotalFileCounter), arg.Counter);

                        foundFilesLabel.BeginInvoke(new CounterDelegate(SetFoundFileCounter), arg.Counter);

                    }
                    catch (Exception err)
                    {
                        statusStripFiles.Text = err.Message;
                    }
                };                

                timer.StartTimer();

                Task.Run(async () =>
                {
                    var fileList = await searcher.FileSearcher(startDirectory, pattern, _cancellationTokenSource.Token, _semaphore).ConfigureAwait(false);

                }).ContinueWith(t =>
                {
                    statusStripLabel.Text = "Done";

                    //startButton.BeginInvoke(new Action(() => { startButton.Enabled = true; }));
                });                
            }
            else
            {
                _isRunning = !_isRunning;
                startButton.Text = "Старт";
                _cancellationTokenSource.Cancel();
                timer.StopTimer();
                pauseButton.Enabled = false;
                stateReset();
            }
        }

        private void AddNode(string fileName)
        {
            var pathSegments = fileName.Split(Path.DirectorySeparatorChar);

            var roots = fileTreeView.Nodes.Find("root", false);

            var rootNode = roots.FirstOrDefault();

            if (rootNode == null)
            {
                rootNode = new TreeNode("root") { Name = "root" };

                fileTreeView.Nodes.Add(rootNode);
            }

            var currentNode = rootNode;

            foreach (var segment in pathSegments)
            {
                var foundSegment = currentNode.Nodes.Find(segment, false)?.FirstOrDefault();

                if (foundSegment == null)
                {
                    var node = new TreeNode(segment) { Name = segment };

                    currentNode.Nodes.Add(node);

                    currentNode = node;
                }
                else
                {
                    currentNode = foundSegment;
                }
            }            
        }

        private void SetTotalFileCounter(Counter counter)
        {
            totalFilesLabel.Text = counter.TotalFiles.ToString();

        }

        private void SetFoundFileCounter(Counter counter)
        {
            foundFilesLabel.Text = counter.FoundFiles.ToString();

        }

        private void SavePathAndPattern()
        {
            var config = new StateFile();
            config.SearchPattern = targetFileInput.Text;
            config.SearchPath = targetDirectoryInput.Text;
            StateFileHelper.WriteConfig(config);
        }

        private void SetTimeElapsed(int timecounter)
        {
            elapsedTimerLabel.Text = timecounter.ToString();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (pauseButton.Text == "Пауза")
            {
                _semaphore.Wait();
                pauseButton.Text = "Продолжить";
            }
            else
            {
                _semaphore.Release();
                pauseButton.Text = "Пауза";
            }
        }

        private void stateReset()
        {
            if (_semaphore.CurrentCount < 1) { _semaphore.Release(); }
            pauseButton.Text = "Пауза";
        }
    }
}
