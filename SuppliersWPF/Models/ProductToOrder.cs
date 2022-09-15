using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SuppliersWPF.Models
{
    public class ProductToOrder : INotifyPropertyChanged
    {
        public int id_orders { get; set; }
        public int id_goods { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
