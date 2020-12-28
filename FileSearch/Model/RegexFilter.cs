using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileSearch.Model
{
    public interface IFilteredFile<T>
    {
        List<string> FilteredFilesList(List<string> source, string pattern);
    }

    public class RegexFilter : IFilteredFile<RegexFilter>
    {
        public List<string> FilteredFilesList(List<string> source, string pattern)
        {
            List<string> _filteredFiles = new List<string>();


            foreach (string file in source)
            {
                var fileName = file.Substring(file.LastIndexOf(@"\") + 1);

                if (Regex.IsMatch(fileName, pattern))
                {
                    _filteredFiles.Add(file);
                    
                }
            }

            return _filteredFiles;
        }
    }
}
