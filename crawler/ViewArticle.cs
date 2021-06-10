using System;

namespace VuTruLink
{
    public class ViewArticle
    {
        public void VnExpressView()
        {
            var vnExpressCrawler = new VnExpressCrawler();
            var listLink = vnExpressCrawler.GetListLink("https://vnexpress.net/suc-khoe");
            for (int i = 0; i < listLink.Count; i++)
            {
                var article = vnExpressCrawler.Craw(listLink[i]);
                if (article != null)
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }

        public void DanTriView()
        {
            var danTriCrawler = new DanTriCrawler();
            var listLink = danTriCrawler.GetListLink("https://dantri.com.vn");
            for (var i = 0; i < listLink.Count; i++)
            {
                var article = danTriCrawler.Craw(listLink[i]);
                if (article != null)
                {
                    Console.WriteLine(article.ToString());
                }
            }
        }
    }
}