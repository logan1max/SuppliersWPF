using SuppliersWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SuppliersWPF
{
    public class CreateOrderViewModel : INotifyPropertyChanged
    {
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                addToOrder(new ProductToOrder { id_goods = selectedProduct.id, price = selectedProduct.price, quantity = 1 });
                OnPropertyChanged("SelectedProduct");
            }
        }
        public List<Product> Goods { get; set; }


        private ProductToOrder selectedToOrder;
        public ProductToOrder SelectedToOrder
        {
            get { return selectedToOrder; }
            set
            {
                selectedToOrder = value;

                OnPropertyChanged("SelectedToOrder");
            }
        }
        public List<ProductToOrder> toOrder { get; set; }


        public CreateOrderViewModel()
        {
            GetGoods();
            toOrder = new List<ProductToOrder>();
        }

        private void GetGoods()
        {
            GoodsRepository gR = new GoodsRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            Goods = gR.GetGoods();
            OnPropertyChanged("Goods");
        }

        private void addToOrder(ProductToOrder productToOrder)
        {
            toOrder.Add(productToOrder);
            OnPropertyChanged("SelectedToOrder");
            OnPropertyChanged("toOrder");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
