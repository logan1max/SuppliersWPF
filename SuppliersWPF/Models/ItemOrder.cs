using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuppliersWPF.Models
{
    public class ItemOrder : INotifyPropertyChanged
    {
        public int idItem { get; set; }
        public string nameItem { get; set; }
        public double quantityItem { get; set; }
        public double priceItem { get; set; }
        public int idSupplier { get; set; }
        public string nameSupplier { get; set; }
        public string addressSupplier { get; set; }
        public double phoneSupplier { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
