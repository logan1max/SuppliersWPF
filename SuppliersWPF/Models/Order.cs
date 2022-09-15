using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuppliersWPF.Models
{
    public class Order : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string name { get; set; }
        public double cost { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
