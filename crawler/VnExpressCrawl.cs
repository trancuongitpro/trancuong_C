using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace VuTruLink
{
    public class VnExpressCrawler: Crawler
    {
         public Article Craw(string url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                var doc = web.Load(url);
                var TitleNode = doc.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-detail')]");
                var title = TitleNode.InnerText;
                var ContentNode = doc.DocumentNode.SelectSingleNode("//article[contains(@class, 'fck-detail')]/a");
                var content = ContentNode.InnerHtml;
                var ImageNode = doc.DocumentNode.SelectSingleNode("//picture/img");
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
            var doc = web.Load("https://vnexpress.net/giai-tri");
            var nodeContent = doc.DocumentNode.SelectNodes("//h3[contains(@class, 'title-news')]/a");
            Console.WriteLine(nodeContent.Count());
            for (int i = 0; i < nodeContent.Count(); i++)
            {
                var link = nodeContent.ElementAt(i).Attributes["href"].Value;
                list.Add(link);
            }   
            for (int i = 0; i < list.Count(); i++)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine(list[i]);
                var document =  web.Load(list[i]);
                var doctitle = document.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-detail')]");
                Console.WriteLine(doctitle.InnerText);
            }
            return null;
        }
    }
}