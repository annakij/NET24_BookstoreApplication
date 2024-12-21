using BookstoreApplication.Domain.Models;
using BookstoreApplication.Infrastructure.Models;
using BookstoreApplication.Presentation.Command;
using BookstoreApplication.Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Presentation.ViewModel;

class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<string>? Stores { get; set; }
    public ObservableCollection<Book>? Books { get; set; }
    public ObservableCollection<Author>? Authors { get; set; }

    private string? _selectedStore;
    public string? SelectedStore
    {
        get => _selectedStore;
        set
        {
            _selectedStore = value;
            LoadBooks();
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(Books));
        }
    }

    private Book? _selectedBook;
    public Book? SelectedBook
    {
        get => _selectedBook;
        set
        {
            _selectedBook = value;
            RaisePropertyChanged();
            ShowBookDetailsCommand.RaiseCanExecuteChanged();
        }
    }
    public Action? ShowBookDetails { get; set; }
    public Action? ShowConfiguration { get; set; }
    public Action? ShowAdjustStock { get; set; }
    public DelegateCommand ShowBookDetailsCommand { get; }
    public DelegateCommand ShowConfigurationCommand { get; }
    public DelegateCommand ShowAdjustStockCommand { get; }

    public MainWindowViewModel()
    {
        ShowBookDetailsCommand = new DelegateCommand(DoShowBookDetails, CanShowBookDetails);
        ShowConfigurationCommand = new DelegateCommand(DoShowConfiguration);
        ShowAdjustStockCommand = new DelegateCommand(DoShowAddRemove);
        LoadStores();
    }

    private void DoShowAddRemove(object obj) => ShowAdjustStock();

    private void DoShowConfiguration(object obj) => ShowConfiguration();

    private void DoShowBookDetails(object obj) => ShowBookDetails();

    private bool CanShowBookDetails(object? arg) => SelectedBook is not null;

    public void LoadStores()
    {
        using var db = new BookstoreContext();

        Stores = new ObservableCollection<string>(
            db.Stores.Select(s => s.Name).ToList()
            );

        SelectedStore = Stores.FirstOrDefault();
    }

    public void LoadBooks() // For further developing, load async as the database grows, so that it doesn't hold up the UI
    {
        if (SelectedStore == null) return;

        using var db = new BookstoreContext();

        Books = new ObservableCollection<Book>(
            db.StockBalances
                .Where(sb => sb.Store.Name == SelectedStore)
                .Select(sb => new Book
                {
                    Title = sb.IsbnNavigation.Title,
                    Isbn13 = sb.IsbnNavigation.Isbn13,
                    Price = sb.IsbnNavigation.Price,
                    Language = sb.IsbnNavigation.Language,
                    ReleaseDate = sb.IsbnNavigation.ReleaseDate,

                    Authors = db.BookAuthors
                        .Where(ba => ba.ISBN == sb.IsbnNavigation.Isbn13)
                        .Select(ba => ba.Author)
                        .ToList(),

                    StockCount = sb.Balance
                })
                .ToList()
        );

        Authors = new ObservableCollection<Author>(
            Books.SelectMany(book => book.Authors).Distinct()
        );

        RaisePropertyChanged(nameof(Books));
        RaisePropertyChanged(nameof(Authors));

    }

}

public class ReviewDetails
{
public string ISBN { get; set; }
public string? Content { get; set; }

public string? Reviewer { get; set; }

public DateOnly? PublishedDate { get; set; }
}

public class AwardDetails
{
public string ISBN { get; set; }
public string? AuthorName { get; set; }
public string? AwardName { get; set; }
public DateOnly? AwardDate { get; set; }
}
