using System;
using System.Configuration;
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

            OrdersRepository ordersRepository = new OrdersRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var orders = ordersRepository.GetOrderItems(1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
