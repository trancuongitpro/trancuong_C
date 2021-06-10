using System.Collections.Generic;

namespace VuTruLink
{
    public interface Crawler
    {
        Article Craw(string url);

        List<string> GetListLink(string ListUrl);
    }
}