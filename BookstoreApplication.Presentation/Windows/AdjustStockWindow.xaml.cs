using BookstoreApplication.Presentation.ViewModel;
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

namespace BookstoreApplication.Presentation.Windows;


public partial class AdjustStockWindow : Window
{
    public AdjustStockWindow()
    {
        InitializeComponent();

        DataContext = new BookConfigViewModel();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
