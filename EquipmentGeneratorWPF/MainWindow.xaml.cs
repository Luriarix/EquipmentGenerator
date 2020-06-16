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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EquipmentGenerator;

namespace EquipmentGeneratorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Processes _test = new Processes();

        public MainWindow()
        {
            InitializeComponent();
            FillList();
        }

        public void FillList()
        {
            ItemList.ItemsSource = _test.ReadList();
        }

        private void ItemList_SelectItem()
        {
            if (ItemList.SelectedItem != null)
            {
                    _test.SelectedItem(ItemList.SelectedItem);
                    FillList();
            }
        }

        private void ItemAdd(object sender, RoutedEventArgs e)
        {
           // _test.AddItem(ItemName.Text);
            _test.AddItem();
            FillList();
            ItemName.Clear();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (ItemList.SelectedItem != null)
                _test.RemoveItem();
            else
                _test.RemoveAllItems();
            FillList();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            _test.Update(ItemList.SelectedIndex , ItemName.Text);
            FillList();
        }
    }
}
