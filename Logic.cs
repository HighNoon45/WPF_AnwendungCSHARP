using Prism.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WPF_Oberflaeche
{
    public class MainViewModel : BindableBase
    {
        //Tests mit ObservanbleCollection für Live Oberfläche
        private ObservableCollection<Good> _goods;
        public ObservableCollection<Good> Goods
        {
            get { return _goods; }
            set
            {
                _goods = value;
                RaisePropertyChanged(nameof(Goods));
            }
        }


        public MainViewModel()
        {
            //hard coded data for testing
            Goods = new ObservableCollection<Good>();
            List<string> names = new List<string>() { "Tammy", "Doug", "Jeff", "Greg", "Kris", "Mike", "Joey", "Leslie", "Emily", "Tom" };
            List<int> ages = new List<int>() { 32, 24, 42, 57, 17, 73, 12, 8, 29, 31 };

            for (int i = 0; i < 10; i++)
            {
                Good item = new Good();
                item.Name = names[i];
                item.Price = ages[i];
                Goods.Add(item);
            }
        }
    }
}
