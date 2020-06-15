using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XamarinForms_20200609.Uebungen.GoogleBooks.Model;
using XamarinForms_20200609.Uebungen.GoogleBooks.Service;

namespace XamarinForms_20200609.Uebungen.GoogleBooks.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private BookService bService;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchString { get; set; }

        public Command SearchCommand { get; set; }

        private ObservableCollection<Item> booklist;
        public ObservableCollection<Item> BookList
        {
            get
            {
                return booklist;
            }
            set
            {
                booklist = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BookList)));
            }
        }

        private void SearchBooks()
        {
            GBook gBook = bService.FindBooks(SearchString);
            BookList = new ObservableCollection<Item>(gBook.Items);
        }

        public MainViewModel()
        {
            bService = new BookService();
            BookList = new ObservableCollection<Item>();

            SearchCommand = new Command(SearchBooks);
        }

    }
}
