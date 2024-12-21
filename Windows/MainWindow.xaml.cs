using BookstoreApplication.Presentation.ViewModel;
using BookstoreApplication.Presentation.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookstoreApplication.Presentation.Windows;

public partial class MainWindow : Window
{
    private MainWindowViewModel viewModel;
    public MainWindow()
    {
        InitializeComponent();

        DataContext = viewModel = new MainWindowViewModel()
        {
            ShowBookDetails = OpenBookDetailsWindow,
            ShowConfiguration = OpenConfiguraionWindow,
            ShowAdjustStock = OpenAdjustStock
        };
    }

    private void OpenAdjustStock()
    {
        var adjustStockWindow = new AdjustStockWindow()
        {
            Owner = Application.Current.MainWindow
        };
        adjustStockWindow.Show();
    }

    private void OpenBookDetailsWindow()
    {
        var detailsWindow = new BookDetailsWindow(viewModel.SelectedBook)
        {
            Owner = Application.Current.MainWindow
        };
        detailsWindow.Show();
    }

    private void OpenConfiguraionWindow()
    {
        var configWindow = new BookConfigurationWindow()
        {
            Owner = Application.Current.MainWindow
        };
        configWindow.Show();
    }


}