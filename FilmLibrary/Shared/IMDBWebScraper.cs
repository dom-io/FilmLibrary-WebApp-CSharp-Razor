using HtmlAgilityPack;
using ScrapySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmLibrary.Shared
{
    public class IMDBWebScraper
    {
        static RefreshMovies()
        {
            var List<string> movieLinks = GetMovieLinks(url: "");
            Console.WriteLine(format: "Found {0} links", arg0: movieLinks.Count);
        }

        static HtmlDocument GetDocument(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            return doc;
        }

        static List<string> GetMovieLinks(string url)
        {
            var List<string> movieLinks = new List<string>();
            HtmlDocument doc GetDocument(url);
            HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes(xpath: "");
            var Uri baseUri = new Uri(uriString: url);

            foreach (var HtmlNode link in linkNodes) 
            {
                string href = linkNodes.Attributes
            }
        }

    }
}
