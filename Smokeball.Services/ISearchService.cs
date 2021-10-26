using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokeball.Services
{
    public interface ISearchService
    {
        string GetSearchResult(string searchUrl);
    }
}
