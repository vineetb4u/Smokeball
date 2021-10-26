using Microsoft.Extensions.Options;
using Smokeball.Services;
using Smokeball.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Smokeball
{
    /// <summary>
    /// Interaction logic for UrlFinder.xaml
    /// </summary>
    public partial class UrlFinder : Window
    {
        private UrlFinderViewModel viewModel;
        private readonly AppSettings settings;
        private readonly ISearchService searchService;
        private enum MessageType { Info, Error };

        public UrlFinder(ISearchService searchService, IOptions<AppSettings> settings)
        {
            InitializeComponent();
            
            viewModel = new UrlFinderViewModel();
            DataContext = viewModel;

            this.searchService = searchService;
            this.settings = settings.Value;

            this.validateSettings(settings.Value);
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Validate();

            if (viewModel.HasErrors)
            {
                return;
            }

            try
            {
                var searchCriteria = getSearchCriteria();

                var searchUrl = $"{settings.BaseUrl}{searchCriteria}";

                var searchResult = this.searchService.GetSearchResult(searchUrl);

                var positions = Utils.FindPositions(searchResult, this.settings.Regex, new Uri(viewModel.Url));

                displayMessage($"URL is found in {positions.ToCsv()} position(s).", MessageType.Info);
            }
            catch (Exception ex)
            {
                displayMessage(ex.Message, MessageType.Error);
            }
        }


        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            txt_message_block.Text = string.Empty;
            txt_search_keywords.Text = string.Empty;
            txt_url.Text = string.Empty;
        }

        private void validateSettings(AppSettings settings)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(settings.BaseUrl))
            {
                errors.Add($"{nameof(settings.BaseUrl)}");
            }

            if (string.IsNullOrEmpty(settings.Regex))
            {
                errors.Add($" {nameof(settings.Regex)}");
            }

            if (errors.Any())
            {
                displayMessage($"{errors.ToCsv()} setting(s) does not exist.", MessageType.Error);
                btn_search.IsEnabled = false;
            }
        }

        private string getSearchCriteria()
        {
            return viewModel.SearchKeywords.Trim().Replace(" ", "+");
        }

        private void displayMessage(string errorMessage, MessageType type)
        {
            txt_message_block.Text = errorMessage;

            if (type == MessageType.Error)
            {
                txt_message_block.Foreground = Brushes.Red;
            }
            else 
            {
                txt_message_block.Foreground = Brushes.Black;
            }
        }

    }
}
