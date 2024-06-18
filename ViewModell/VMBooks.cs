using PR43.Context;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

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
                    if (AuthorsContext.AllAuthors().ToList().Count > 0)
                    {
                        BooksContext newModell = new Context.BooksContext(true);
                        Books.Add(newModell);
                        MainWindow.MW.frame.Navigate(new View.AddBook(newModell));
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить запись так как список авторов пуст.\nДобавьте нового автора чтобы продолжить.", "Предупреждение");
                    }
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
