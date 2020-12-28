using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch.Model
{
    public class Counter
    {
        public long TotalFiles { get; private set; }
        public long FoundFiles { get; private set; }

        public long IncrementTotalFilesCounter()
        {
            TotalFiles++;

            return TotalFiles;
        }

        public long IncrementFoundFilesCounter()
        {
            FoundFiles++;

            return FoundFiles;
        }
    }
}
