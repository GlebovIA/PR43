using PR43.Context;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PR43.ViewModell
{
    public class VMBooks : INotifyPropertyChanged
    {
        public ObservableCollection<Context.BooksContext> Books { get; set; }
        public Classes.RelayCommand NewBook
        {
            get
            {
                return new Classes.RelayCommand(obj =>
                {
                    BooksContext newModell = new Context.BooksContext(true);
                    Books.Add(newModell);
                    MainWindow.MW.frame.Navigate(new View.AddBook(newModell));
                });
            }
        }
        public VMBooks() => Books = BooksContext.AllBooks();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
