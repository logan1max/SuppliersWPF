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
        public int _idItem;
        public string _nameItem;
        public double _quantityItem;
        public double _priceItem;
        public int _idSupplier;
        public string _nameSupplier;
        public string _addressSupplier;
        public double _phoneSupplier;

        public int idItem
        {
            get { return _idItem; }
            set { _idItem = value; OnPropertyChanged("idItem"); }
        }
        public string nameItem
        {
            get { return _nameItem; }
            set { _nameItem = value; OnPropertyChanged("nameItem"); }
        }
        public double quantityItem
        {
            get { return _quantityItem; }
            set { _quantityItem = value; OnPropertyChanged("quantity"); }
        }
        public double priceItem
        {
            get { return _priceItem; }
            set { _priceItem = value; OnPropertyChanged("priceItem"); }
        }
        public int idSupplier
        {
            get { return _idSupplier; }
            set { _idSupplier = value; OnPropertyChanged("idSupplier"); }
        }
        public string nameSupplier
        {
            get { return _nameSupplier; }
            set { _nameSupplier = value; OnPropertyChanged("nameSupplier"); }
        }
        public string addressSupplier
        {
            get { return _addressSupplier; }
            set { _addressSupplier = value; OnPropertyChanged("addressSupplier"); }
        }
        public double phoneSupplier
        {
            get { return _phoneSupplier; }
            set { _phoneSupplier = value; OnPropertyChanged("phoneSupplier"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
