using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_BlackdotTechTest.Models
{
    public class SearchResults
    {
        private string _heading;
        private string _url;
        private string _price;
        private string _source;

        public string Heading
        {
            get { return _heading; }
            set { _heading = value; }
        }
        // public string Url { get; set; }
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }
    }
}
