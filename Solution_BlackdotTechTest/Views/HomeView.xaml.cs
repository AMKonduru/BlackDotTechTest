using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Solution_BlackdotTechTest.ViewModels;
using Caliburn.Micro;
using Solution_BlackdotTechTest.Models;
using System.Net.Http;
using HtmlAgilityPack;
using System.Windows;
using System.Text.RegularExpressions;

namespace Solution_BlackdotTechTest.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// Note: Caliburn.Micro has been installed 
    /// </summary>
    public partial class HomeView : Window
    {
        BindableCollection<SearchResults> LstSearchResults;
        public HomeView()
        {
            InitializeComponent();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            myListView.ItemsSource = SearchNow(SearchTerm.Text);
            
        }

        public BindableCollection<SearchResults> SearchNow(string searchTerm)
        {
            ///Search to begin for the search term across both the sites and then combining the results.
            try
            {
                var lstSearchResults = new List<SearchResults>();
                var lstMoreSearchResults = new List<SearchResults>();
                SearchHelper cls = new SearchHelper();


                var urlWordery = $"https://wordery.com/search?term=" + Convert.ToString(searchTerm);
                var urlBookDepository = $"https://www.bookdepository.com/search?searchTerm=" + Convert.ToString(searchTerm);

                HtmlWeb web = new HtmlWeb();
                web.AutoDetectEncoding = false;
                web.OverrideEncoding = Encoding.Default;

                HtmlDocument doc = web.Load(urlWordery);
                lstSearchResults = cls.searchWordery(doc);

                doc = web.Load(urlBookDepository);
                lstMoreSearchResults = cls.searchBookDepository(doc);

                lstSearchResults.AddRange(lstMoreSearchResults);
                lstSearchResults.Sort((x, y) => x.Heading.CompareTo(y.Heading));

                LstSearchResults = new BindableCollection<SearchResults>(lstSearchResults);
                return LstSearchResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            SearchTerm.Text = "";
            LstSearchResults.Clear();
        }


    }
}
