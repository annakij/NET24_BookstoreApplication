using BookstoreApplication.Domain.Models;
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

public partial class BookDetailsWindow : Window
{
    public BookDetailsWindow(Book book)
    {
        InitializeComponent();

        DataContext = new BookDetailsViewModel(book);

    }
}
