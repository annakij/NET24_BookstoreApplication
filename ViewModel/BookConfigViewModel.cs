using BookstoreApplication.Presentation.Windows;
using BookstoreApplication.Domain.Models;
using BookstoreApplication.Infrastructure.Models;
using BookstoreApplication.Presentation.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookstoreApplication.Presentation.ViewModel;

internal class BookConfigViewModel : ViewModelBase
{
    public ObservableCollection<string>? BookTitles { get; set; }
    public ObservableCollection<string>? Stores { get; set; }

    private string _selectedStore;
    public string SelectedStore
    {
        get => _selectedStore;
        set
        {
            _selectedStore = value;
            RaisePropertyChanged();
            AddBookCommand?.RaiseCanExecuteChanged();
            RemoveBookCommand?.RaiseCanExecuteChanged();
        }
    }
    private string _selectedBookTitle;
    public string SelectedBookTitle
    {
        get => _selectedBookTitle;
        set
        {
            _selectedBookTitle = value;
            RaisePropertyChanged(nameof(SelectedBookTitle));
            UpdateMaxStockAmount(SelectedStoreFrom);
            BookTransferCommand?.RaiseCanExecuteChanged();
            AddBookCommand?.RaiseCanExecuteChanged();
            RemoveBookCommand?.RaiseCanExecuteChanged();

        }
    }

    private string _selectedStoreTo;
    public string SelectedStoreTo
    {
        get => _selectedStoreTo;
        set
        {
            _selectedStoreTo = value;
            RaisePropertyChanged();
            BookTransferCommand?.RaiseCanExecuteChanged();
        }
    }

    private string _selectedStoreFrom;
    public string SelectedStoreFrom
    {
        get => _selectedStoreFrom;
        set
        {
            _selectedStoreFrom = value;
            RaisePropertyChanged();
            UpdateMaxStockAmount(SelectedStoreFrom);
            BookTransferCommand?.RaiseCanExecuteChanged();

        }
    }

    private int _stockAmount;
    public int StockAmount
    {
        get => _stockAmount;
        set
        {
            _stockAmount = value;
            RaisePropertyChanged();
            BookTransferCommand?.RaiseCanExecuteChanged();
            AddBookCommand?.RaiseCanExecuteChanged();
            RemoveBookCommand?.RaiseCanExecuteChanged();
        }
    }

    public DelegateCommand BookTransferCommand { get; set; }
    public DelegateCommand AddBookCommand { get; set; }
    public DelegateCommand RemoveBookCommand { get; set; }


    private int _maxStockAmount;
    public int MaxStockAmount
    {
        get => _maxStockAmount;
        set
        {
            _maxStockAmount = value;
            RaisePropertyChanged();
        }
    }

    public BookConfigViewModel()
    {
        LoadBooksAndStores();

        BookTransferCommand = new DelegateCommand(BookTransfer, CanTransferBook);
        AddBookCommand = new DelegateCommand(AddBook, CanAdjustStock);
        RemoveBookCommand = new DelegateCommand(RemoveBook, CanAdjustStock);

    }

    private bool CanAdjustStock(object? arg) => StockAmount > 0;
    private void RemoveBook(object obj)
    {
        AdjustStock(SelectedBookTitle, SelectedStore, -StockAmount);

        if (obj is Window window)
        {
            window.Close();
        }
    }

    private void AddBook(object obj)
    {
        AdjustStock(SelectedBookTitle, SelectedStore, StockAmount);

        if (obj is Window window)
        {
            window.Close();
        }
    }

    private void BookTransfer(object obj)
    {
        ProcessTransferBooks(SelectedBookTitle, SelectedStoreTo, SelectedStoreFrom, StockAmount);

        if (obj is Window window)
        {
            window.Close();
        }
    }

    private bool CanTransferBook(object? arg)
    {
        return StockAmount > 0 &&
               SelectedStoreTo != SelectedStoreFrom;
    }

    public void AdjustStock(string bookTitle, string storeName, int amount)
    {
        using var db = new BookstoreContext();

        var book = db.Books.FirstOrDefault(b => b.Title == bookTitle);
        var store = db.Stores.FirstOrDefault(s => s.Name == storeName);

        var stock = db.StockBalances
            .FirstOrDefault(sb => sb.StoreId == store.Id && sb.Isbn == book.Isbn13);

        if (stock == null)
        {
            stock = new StockBalance
            {
                StoreId = store.Id,
                Isbn = book.Isbn13,
                Balance = 0
            };
            db.StockBalances.Add(stock);
        }

        stock.Balance += amount;

        if (stock.Balance < 0)
        {
            stock.Balance = 0;

            MessageBox.Show("Your suggested amount is more than in stock. The stock has been cleared to 0.",
                            "Stock Adjustment Warning",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                            );
        }


        db.SaveChanges();
    }

    public void ProcessTransferBooks(string bookTitle, string storeTo, string storeFrom, int amount)
    {
        using var db = new BookstoreContext();

        var toStore = db.Stores.FirstOrDefault(s => s.Name == storeTo);
        var fromStore = db.Stores.FirstOrDefault(s => s.Name == storeFrom);
        var book = db.Books.FirstOrDefault(b => b.Title == bookTitle);

        var toStock = db.StockBalances.FirstOrDefault(sb => sb.StoreId == toStore.Id && sb.Isbn == book.Isbn13);
        if (toStock == null)
        {
            toStock = new StockBalance
            {
                StoreId = toStore.Id,
                Isbn = book.Isbn13,
                Balance = 0
            };
            db.StockBalances.Add(toStock);
        }

        var fromStock = db.StockBalances.FirstOrDefault(sb => sb.StoreId == fromStore.Id && sb.Isbn == book.Isbn13);

        fromStock.Balance -= amount;
        toStock.Balance += amount;

        db.SaveChanges();
    }

    private void UpdateMaxStockAmount(string storeFrom)
    {
        using var db = new BookstoreContext();

        var store = db.Stores.FirstOrDefault(s => s.Name == storeFrom);

        if (!string.IsNullOrEmpty(SelectedBookTitle) && SelectedStoreFrom != null)
        {
            var book = db.Books.FirstOrDefault(b => b.Title == SelectedBookTitle);
            if (book != null)
            {
                var stock = db.StockBalances
                    .FirstOrDefault(sb => sb.StoreId == store.Id && sb.Isbn == book.Isbn13);

                MaxStockAmount = stock?.Balance ?? 0;
            }
        }
        else
        {
            MaxStockAmount = 0;
        }
    }

    public void LoadBooksAndStores()
    {
        using var db = new BookstoreContext();

        BookTitles = new ObservableCollection<string>(
               db.Books.Select(b => b.Title).ToList()
               );

        SelectedBookTitle = BookTitles.FirstOrDefault();

        Stores = new ObservableCollection<string>(
            db.Stores.Select(s => s.Name).ToList()
            );

        SelectedStoreFrom = SelectedStoreTo = SelectedStore = Stores.FirstOrDefault();

        BookTransferCommand?.RaiseCanExecuteChanged();

    }
}

