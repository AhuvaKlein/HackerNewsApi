using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace HackerNewsApi.Api
{
    public class TopNewRepository
    {
        private IEnumerable<int> GetTopIds()
        {
            var client = new HttpClient();
            string url = $"https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
            string json = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<IEnumerable<int>>(json);
            return result;
        }

        public IEnumerable<TopNews> GetTopNews()
        {
            IEnumerable<int> ids = GetTopIds().Take(20);
            List<TopNews> topnews = new List<TopNews>();
            foreach(int i in ids)
            {
                var client = new HttpClient();
                string url = $"https://hacker-news.firebaseio.com/v0/item/{i}.json?print=pretty";
                string json = client.GetStringAsync(url).Result;
                topnews.Add(JsonConvert.DeserializeObject<TopNews>(json));
            }
            return topnews;
        }
    }

}
