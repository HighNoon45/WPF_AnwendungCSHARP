using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popkorn
{
    public class Good : BindableBase
    {
        private string _name = default;
        private double _price;
        private int _quantity;
        private bool _isselected;

        public string Name 
        { 
            get 
            {
                return _name; 
            } 
            set 
            {
                _name = value;
            } 
        }
        public double Price 
        {
            get 
            {
                return _price; 
            }
            set 
            {
                _price = value;
            } 
        }
        public int Quantity 
        {
            get 
            {
                return _quantity; 
            }
            set 
            {
                _quantity = value;
                RaisePropertyChanged(nameof(Quantity)); 
            } 
        }
        public bool IsSelected 
        {
            get 
            {
                return _isselected; 
            }
            set 
            {
                _isselected = value;
                RaisePropertyChanged(nameof(IsSelected)); 
            } 
        }
    }
    public class Kunde
    {
        public int Kundennummer;
        public string Vorname;
        public string Name;
        public string Straße;
        public string Ort;
        public string Plz;
        public string EMail;
        public string Mobilnummer;
    }
}
