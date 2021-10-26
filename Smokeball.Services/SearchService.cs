using System;
using System.Net;

namespace Smokeball.Services
{
    public class SearchService : ISearchService
    {
        public string GetSearchResult(string searchUrl)
        {
            if (string.IsNullOrEmpty(searchUrl))
            {
                throw new ArgumentNullException(nameof(searchUrl));
            }

            using (WebClient client = new WebClient())
            {
                // specify encoding
                client.Encoding = System.Text.UTF8Encoding.UTF8;

                // output
                return client.DownloadString(searchUrl);
            }
        }
    }
}
