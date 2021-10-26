using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Smokeball.Utilities
{
    public class Utils
    {
        public static List<int> FindPositions(string html, string pattern, Uri urlToSearch)
        {
            if (string.IsNullOrEmpty(html))
            {
                throw new ArgumentNullException(nameof(html));
            }

            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentNullException(nameof(pattern));
            }

            if (urlToSearch is null)
            {
                throw new ArgumentNullException(nameof(urlToSearch));
            }

            var lookup = new Regex(pattern);
            var positions = new List<int>();

            MatchCollection matches = lookup.Matches(html);
            for (int i = 0; i < matches.Count; i++)
            {
                string match = matches[i].Groups[2].Value;
                if (match.Contains(urlToSearch.Host))
                {
                    i += 1;
                    positions.Add(i);
                }

            }

            return positions;
        }
    }
}
