﻿using SuppliersWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SuppliersWPF
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        private int _id;

        private ItemOrder selectedItem;
        public ObservableCollection<ItemOrder> Items { get; set; }
        public ItemOrder SelectedItem
        {
            get { return selectedItem; }
            set 
            { 
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private Order selectedOrder;
        public ObservableCollection<Order> _Orders;
        public ObservableCollection<Order> Orders
        {
            get { return _Orders; }
            set { _Orders = value; OnPropertyChanged("Orders"); }
        }
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                FillItems(SelectedOrder.id);
                OnPropertyChanged("SelectedOrder");
            }
        }

        public OrdersViewModel()
        {
            OrdersRepository ordersRepository = new OrdersRepository();

            var orders = ordersRepository.GetOrders();
            ObservableCollection<Order> _orders = new ObservableCollection<Order>();
            foreach (var order in orders)
            {
                _orders.Add(order);
            }
            _Orders = _orders;
        }

        public void FillItems(int id)
        {
            OrdersRepository ordersRepository = new OrdersRepository();
            var items = ordersRepository.GetOrderItems(id);
            ObservableCollection<ItemOrder> _items = new ObservableCollection<ItemOrder>();
            foreach (var item in items)
            {
                _items.Add(item);
            }
            Items = _items;
            OnPropertyChanged("Items");
        }

        private RelayCommand update;
        public RelayCommand Update
        {
            get
            {
                return update ??
                    (update = new RelayCommand(obj =>
                    {
                        OrdersRepository ordersRepository = new OrdersRepository();

                        var items = ordersRepository.GetOrderItems(SelectedOrder.id);
                        ObservableCollection<ItemOrder> _items = new ObservableCollection<ItemOrder>();
                        foreach (var item in items)
                        {
                            _items.Add(item);
                        }
                        Items = _items;
                    }));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
