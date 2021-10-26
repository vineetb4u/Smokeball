using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokeball
{
    public partial class UrlFinderViewModel
    {
        public UrlFinderViewModel()
        {
        }
       
        private string _searchKeywords;
        public string SearchKeywords
        {
            get { return _searchKeywords; }
            set
            {
                _searchKeywords = value;
                OnPropertyChanged("SearchKeywords");
            }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged("Url");
            }
        }
    }
}
