using BookstoreApplication.Domain.Models;
using BookstoreApplication.Infrastructure.Models;
using BookstoreApplication.Presentation.Command;
using BookstoreApplication.Presentation.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApplication.Presentation.ViewModel
{
    internal class BookDetailsViewModel : ViewModelBase
    {
        public ObservableCollection<ReviewDetails> BookReviews { get; set; }

        public ObservableCollection<AwardDetails> AuthorAwardDetails { get; set; }

        public Book? SelectedBook { get; set; }

        public string? AuthorName { get; set; }

        public DelegateCommand CloseWindowCommand { get; }

        private string? _bookTitle;

        public string? BookTitle
        {
            get => _bookTitle;
            set
            {
                _bookTitle = value;
                RaisePropertyChanged();
            }
        }

        public BookDetailsViewModel()
        {

        }
        public BookDetailsViewModel(Book book)
        {

            LoadBookDetails(book.Isbn13);
            LoadAuthorAwards(book.Isbn13);

            CloseWindowCommand = new DelegateCommand(CloseWindow);
        }

        private void CloseWindow(object obj)
        {
            if (obj is BookDetailsWindow window)
            {
                window.Close();
            }
        }

        public void LoadBookDetails(string isbn)
        {
            using var db = new BookstoreContext();

            BookReviews = new ObservableCollection<ReviewDetails>(
                db.Reviews
                  .Where(r => r.Isbn == isbn)
                  .Select(r => new ReviewDetails
                  {
                      Content = string.IsNullOrWhiteSpace(r.Content) ? "This book doesn't have any saved reviews." : r.Content,
                      Reviewer = r.Source,
                      PublishedDate = r.PublishedDate
                  })
                  .ToList()
            );

            BookTitle = db.Books
                          .Where(b => b.Isbn13 == isbn)
                          .Select(b => b.Title)
                          .FirstOrDefault();
        }

        public void LoadAuthorAwards(string isbn)
        {
            using var db = new BookstoreContext();

            AuthorAwardDetails = new ObservableCollection<AwardDetails>(
                db.BookAuthors
                  .Where(ba => ba.ISBN == isbn)
                  .Include(ba => ba.Author)
                  .ThenInclude(a => a.AuthorAwards)
                  .ThenInclude(aa => aa.Award)
                  .SelectMany(ba => ba.Author.AuthorAwards.Select(aa => new AwardDetails
                  {
                      AuthorName = $"{ba.Author.FirstName} {ba.Author.LastName}",
                      AwardName = aa.Award.AwardTitle,
                      AwardDate = aa.AwardDate
                  }))
                  .ToList()
            );

            AuthorName = db.BookAuthors
                           .Where(ba => ba.ISBN == isbn)
                           .Include(ba => ba.Author)
                           .Select(ba => $"{ba.Author.FirstName} {ba.Author.LastName}")
                           .FirstOrDefault();

        }


    }
}

