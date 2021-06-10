using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace VuTruLink
{
    public class DanTriCrawler : Crawler
    {
        public Article Craw(string url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                var doc = web.Load(url);
                var TitleNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'news-item')]/h3[contains(@class,'news-item__title')]/a");
                var title = TitleNode.InnerText;
                var ContentNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'news-item')]/div[contains(@class,'news-item__content')]/a");
                var content = ContentNode.InnerHtml;
                var ImageNode = doc.DocumentNode.SelectSingleNode("div[contains(@class, 'news-item')]/a[contains(@class,'news-item__avatar')]/div[contains(@class, 'dt-thumbnail')]/img");
                var image = ImageNode.Attributes["src"].Value;
                var article = new Article
                {
                    Title = title,
                    Content = content,
                    Image = image,
                    Url = url
                };
                return article;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<string> GetListLink(string listUrl)
        {
            var list = new List<string>();
            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(listUrl);
            var nodeContent = doc.DocumentNode.SelectNodes("//div[contains(@class, 'news-item')]/h3[contains(@class,'news-item__title')]/a");
            Console.WriteLine(nodeContent.Count());
            for (int i = 0; i < nodeContent.Count(); i++)
            {
                var link = nodeContent.ElementAt(i).Attributes["href"].Value;
                list.Add(link);
            }
            return null;
        }
    }
}