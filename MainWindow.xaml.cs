using System.Windows;
using System.Windows.Input;

namespace PR43
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow MW;
        public static View.Main Main = new View.Main();
        public MainWindow()
        {
            InitializeComponent();
            MW = this;
            frame.Navigate(Main);
        }
        private void OpenIndex(object sender, MouseButtonEventArgs e) => frame.Navigate(Main);
    }
}
