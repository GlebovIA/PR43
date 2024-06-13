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
                    BooksContext.ItemsContext newModell = new Context.ItemsContext(true);
                    Books.Add(newModell);
                    MainWindow.MW.frame.Navigate(new View.Add(newModell));
                });
            }
        }
        public VMBooks() => Books = BooksContext.AllItems();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
