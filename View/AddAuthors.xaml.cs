using System.Windows.Controls;

namespace PR43.View
{
    /// <summary>
    /// Логика взаимодействия для AddAuthors.xaml
    /// </summary>
    public partial class AddAuthors : Page
    {
        public AddAuthors(object Context)
        {
            InitializeComponent();
            DataContext = new
            {
                author = Context,
            };
        }
    }
}
