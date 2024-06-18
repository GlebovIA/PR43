using PR43.ViewModell;
using System.Windows.Controls;

namespace PR43.View
{
    /// <summary>
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Page
    {
        public AddBook(object Context)
        {
            InitializeComponent();
            DataContext = new
            {
                book = Context,
                authors = new VMAuthors().Authors
            };
        }
    }
}
