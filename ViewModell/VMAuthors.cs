using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PR43.ViewModell
{
    public class VMAuthors
    {
        public ObservableCollection<Context.AuthorsContext> Authors { get; set; }
        public Classes.RelayCommand NewAuthor
        {
            get
            {
                return new Classes.RelayCommand(obj =>
                {
                    Context.AuthorsContext newModell = new Context.AuthorsContext(true);
                    Authors.Add(newModell);
                    MainWindow.MW.frame.Navigate(new View.Add(newModell));
                });
            }
        }
        public VMAuthors() => Authors = AuthorsContext.AllItems();
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
