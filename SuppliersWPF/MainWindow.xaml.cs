using System.Windows;


namespace SuppliersWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UserRepository userRepository = new UserRepository();

            var users = userRepository.GetUsers();
            var user1 = userRepository.Get(2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
