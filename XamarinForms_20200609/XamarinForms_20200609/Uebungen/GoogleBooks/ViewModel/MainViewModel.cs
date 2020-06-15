using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XamarinForms_20200609.Uebungen.GoogleBooks.Model;
using XamarinForms_20200609.Uebungen.GoogleBooks.Service;

//vgl. BspMVVM/ViewModel
namespace XamarinForms_20200609.Uebungen.GoogleBooks.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Service
        private BookService bService;

        //Interface-Event
        public event PropertyChangedEventHandler PropertyChanged;

        //Properties für DataBinding
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

        //Command-Methode
        private void SearchBooks()
        {
            GBook gBook = bService.FindBooks(SearchString);
            BookList = new ObservableCollection<Item>(gBook.Items);
        }

        //Konstruktor
        public MainViewModel()
        {
            bService = new BookService();
            BookList = new ObservableCollection<Item>();

            SearchCommand = new Command(SearchBooks);
        }

    }
}
