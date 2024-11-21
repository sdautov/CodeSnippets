using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private readonly ActivityLogService _service;
        private int _currentPage = 1;
        private const int PageSize = 100;

        public MainWindow()
        {
            InitializeComponent();

            var context = new ApplicationDbContext();
            _service = new ActivityLogService(context);

            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            var data = await _service.GetActivityLogsAsync(_currentPage, PageSize);
            ActivityDataGrid.ItemsSource = data;
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadDataAsync();
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            LoadDataAsync();
        }
    }
}
