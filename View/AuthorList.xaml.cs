using PR43.ViewModell;
using System.Windows.Controls;

namespace PR43.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorList.xaml
    /// </summary>
    public partial class AuthorList : Page
    {
        public AuthorList()
        {
            InitializeComponent();
            DataContext = new VMAuthors();
        }
    }
}
