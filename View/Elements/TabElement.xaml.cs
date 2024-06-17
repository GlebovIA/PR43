using System.Windows.Controls;
using System.Windows.Input;

namespace PR43.View.Elements
{
    /// <summary>
    /// Логика взаимодействия для TabElemant.xaml
    /// </summary>
    public partial class TabElement : UserControl
    {
        public enum Lists { Books, Authors }
        public TabElement(string name, string source, Lists list)
        {
            InitializeComponent();
            switch (list)
            {
                case Lists.Books:
                    this.MouseDown += (s, a) => MainWindow.Main.frame.Navigate(new BookList());
                    break;
                case Lists.Authors:
                    this.MouseDown += (s, a) => MainWindow.Main.frame.Navigate(new AuthorList());
                    break;
            }
            DataContext = new
            {
                Name = name,
                Source = source,

            };
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
