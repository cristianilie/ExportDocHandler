using System.Collections.Generic;

namespace ExportDocHandles
{
    public interface IWordsToExcludeRequester
    {
        void FilteringComplete(List<string> wordsToExclude);
    }
}
