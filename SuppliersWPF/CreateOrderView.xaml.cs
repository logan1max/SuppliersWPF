using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuppliersWPF
{
    /// <summary>
    /// Логика взаимодействия для GetGoodsView.xaml
    /// </summary>
    public partial class CreateOrderView : Window
    {
        public CreateOrderView()
        {
            InitializeComponent();
            DataContext = new CreateOrderViewModel();
            
        }
    }
}
