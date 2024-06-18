using System.Windows.Controls;
using System.Windows.Input;

namespace PR43.View.Elements
{
    /// <summary>
    /// Логика взаимодействия для TabElemant.xaml
    /// </summary>
    public partial class TabElement : UserControl
    {
        private Main _main;
        public enum Lists { Books, Authors }
        public TabElement(string name, string source, Lists list, Main main)
        {
            InitializeComponent();
            _main = main;
            switch (list)
            {
                case Lists.Books:
                    this.MouseDown += (s, a) => _main.frame.Navigate(_main.Books);
                    break;
                case Lists.Authors:
                    this.MouseDown += (s, a) => _main.frame.Navigate(_main.Authors);
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
