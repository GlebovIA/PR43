using PR43.ViewModell;
using System.Windows.Controls;

namespace PR43.View
{
    /// <summary>
    /// Логика взаимодействия для BookList.xaml
    /// </summary>
    public partial class BookList : Page
    {
        public BookList()
        {
            InitializeComponent();
            DataContext = new VMBooks();
        }
    }
}
