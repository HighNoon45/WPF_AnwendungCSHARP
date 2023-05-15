using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// https://stackoverflow.com/questions/34314339/display-selected-listbox-items-data-in-wpf
// https://www.c-sharpcorner.com/UploadFile/raj1979/simple-mvvm-pattern-in-wpf/#:~:text=MVVM%20is%20a%20way%20of,together%20with%20less%20technical%20difficulties.
//https://www.codeproject.com/Articles/1004644/ObservableCollection-Simply-Explained
namespace Popkorn
{
    public partial class MainWindow : Window
    {
        public MainViewModel L1 = new MainViewModel();
        public MainWindow()
        {
            //SqlConnector myConnector = new SqlConnector();
            //var goodsWindow = new GoodsWindow(myConnector);
            //var tmp2 = new PurchaseWindow(myConnector);
            this.SizeToContent = SizeToContent.WidthAndHeight;
            InitializeComponent();
            DataContext= this;
            Listbox.ItemsSource = L1.Goods;
            Listbox2.ItemsSource = MyGoods;
            Listbox3.ItemsSource = MyGoods;
        }
        public List<Good> MyGoods = new List<Good>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int once = 0;
            double content = 0;
            foreach (Good obj in Listbox.SelectedItems)
            {                
                int i = 0;
                MyGoods.Insert(i, obj);
                if (Qty.Text == "" || Qty.Text == Convert.ToString(0))
                {
                    MyGoods[i].Quantity = MyGoods[i].Quantity + 1;
                    Qty.Text = "1";
                }
                else
                {
                    MyGoods[i].Quantity = MyGoods[i].Quantity + Convert.ToInt32(Qty.Text);
                }
                for (int y = MyGoods.Count - 1; y > 0; y--)
                {
                    for (int z = 0; z < MyGoods.Count; z++)
                    {
                        if (obj.Name.Equals(MyGoods[y].Name))
                        {
                            if (once < 1)
                            {
                                MyGoods.RemoveAt(y);
                                y--;
                            }
                            else
                            {
                                continue;
                            }
                            once++;
                        }
                    }
                }
                i++;
                once = 0;
            }
            foreach (Good obj in MyGoods)
            {
                content = content + (obj.Price * obj.Quantity);
            }
            PriceLabel.Content = "Cart price: " + Convert.ToString(content) + "$";
            Listbox2.Items.Refresh();
            BtnTextMod("Dein Geld ist ", "wertlos", Button, FontWeights.Normal, FontStyles.Italic);
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            double content = 0;
            foreach (Good obj in Listbox2.SelectedItems)
            {
                int once = 0;
                for (int y = 0; y <= MyGoods.Count - 1; y++)
                {
                    if (obj.Name.Equals(MyGoods[y].Name) && once < 1)
                    {
                        if (QtyRm.Text == "" || QtyRm.Text == Convert.ToString(0))
                        {
                            MyGoods[y].Quantity = MyGoods[y].Quantity - 1;
                            QtyRm.Text = "1";
                        }
                        else
                        {
                            MyGoods[y].Quantity = MyGoods[y].Quantity - Convert.ToInt32(QtyRm.Text);
                        }
                        if (MyGoods[y].Quantity <= 0)
                        {
                            MyGoods[y].Quantity = 0;
                            MyGoods.RemoveAt(y);
                        }
                        else
                        {
                            continue;
                        }
                        once++;
                    }
                }
            }
            foreach (Good obj in MyGoods)
            {
                content = content + (obj.Price * obj.Quantity);
            }
            PriceLabel.Content = "Cart price: " + Convert.ToString(content) + "$";
            Listbox2.Items.Refresh();
            BtnTextMod("Wenn du es nicht ", "ausgibst", Button2, FontWeights.Bold, FontStyles.Normal);
        }
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = true;
        }
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            myPopup.IsOpen = false;
        }
        private void BtnTextMod(string _firstString, string _secondString, Button _btn, FontWeight _bet, FontStyle _fontStyle)
        {
            var tbl = new TextBlock();
            Run firstString = new Run();
            firstString.Text = _firstString;
            firstString.FontWeight = FontWeights.Normal;
            firstString.FontStyle = FontStyles.Normal;
            Run secondString = new Run();
            secondString.Text = _secondString;
            secondString.FontWeight = _bet;
            secondString.FontStyle = _fontStyle;
            tbl.Inlines.Add(firstString);
            tbl.Inlines.Add(secondString);
            _btn.Content = tbl;
        }
        private int CcalPurchasementSummary()
        {
            return 0;
        }
        private bool IsPurchasementValid(bool state)
        {
            return false;
        }
    }
}