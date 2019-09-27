using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Solution_BlackdotTechTest.Models;
using System.Net.Http;
using HtmlAgilityPack;
using System.Windows;

namespace Solution_BlackdotTechTest.ViewModels
{
    public class HomeViewModel : Screen
    {
        public BindableCollection<SearchResults> LstSearchResults { get; set; }
        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; NotifyOfPropertyChange(() => SearchTerm); }
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void Reset()
        {
            SearchTerm = "";
        }
    }
}
