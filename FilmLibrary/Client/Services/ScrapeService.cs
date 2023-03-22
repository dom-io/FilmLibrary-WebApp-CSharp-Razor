using HtmlAgilityPack;

namespace FilmLibrary.Client.Services
{
    public class ScrapeService
    {
        public async Task<List<string>> StartScrape()
        {
            List<string> scrapeListTitles = new List<string>();
            //List<string> scrapeListRatings = new List<string>();

            HttpClient hc = new HttpClient();
            HttpResponseMessage result = await hc.GetAsync($"https://www.imdb.com/chart/top/?ref_=nv_mv_250");
            Stream stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(stream);

            var TitleNames = doc.DocumentNode.SelectNodes("//td[@class='titleColumn']");
            var Ratings = doc.DocumentNode.SelectNodes("//td/strong");

            foreach (var titleName in TitleNames)
            {
                scrapeListTitles.Add(titleName.InnerText);
            }

            //foreach ( var rating in Ratings)
            //{
            //    scrapeListRatings.Add(rating.InnerText);
            //}

            return scrapeListTitles;
            // return scrapeListRatings;
        }
    }
}
