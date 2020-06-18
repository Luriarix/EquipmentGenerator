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
        private Processes _process = new Processes();

        public MainWindow()
        {
            InitializeComponent();
            FillItemList();
            FillRaretyList();
            FillTypeList();
        }

        public void FillItemList()
        {
            ItemList.ItemsSource = _process.ReadItemList();
        }
        public void FillRaretyList()
        {
            RaretyList.ItemsSource = _process.ReadRaretiesList();
        }
        public void FillTypeList()
        {
            TypeList.ItemsSource = _process.ReadTypesList();
        }
        public void FillProperties()
        {
            DurabilityAmount.Text =  _process.ActiveItem.ItemProperty.Durability.ToString();
            StrengthAmount.Text = _process.ActiveItem.ItemProperty.Strength.ToString();
            DexterityAmount.Text = _process.ActiveItem.ItemProperty.Dexterity.ToString();
            IntelligenceAmount.Text = _process.ActiveItem.ItemProperty.Inteligence.ToString();
            AttackAmount.Text = _process.ActiveItem.ItemProperty.Attack.ToString();
        }

        private void ItemAdd(object sender, RoutedEventArgs e)
        {
            if (ItemName.Text != null)
                _process.AddItem(ItemName.Text);
            else
                _process.AddItem();
            FillItemList();
            ItemName.Clear();
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (ItemList.SelectedItem != null)
            _process.RemoveItem();
            FillItemList();
        }

        private void UpdateItem(object sender, RoutedEventArgs e)
        {
            _process.UpdateItem(ItemList.SelectedIndex , ItemName.Text);
            FillItemList();
        }

        private void ItemList_SelectItem(object sender, SelectionChangedEventArgs e)
        {
            if (ItemList.SelectedItem != null)
            {
                _process.SelectedItem(ItemList.SelectedItem);
                TypeList.SelectedItem = _process.ActiveItem.ItemType;
                RaretyList.SelectedItem = _process.ActiveItem.CommonItemRarety;
            }
        }


        private void AddType(object sender, RoutedEventArgs e)
        {
            if (TypeName.Text != null)
                _process.AddType(TypeName.Text);
            else
                _process.AddType();
            FillTypeList();
            TypeName.Clear();
        }

        private void DeleteType(object sender, RoutedEventArgs e)
        {
            if (TypeList.SelectedItem != null)
            _process.RemoveType();
            FillTypeList();
        }

        private void UpdateType(object sender, RoutedEventArgs e)
        {

        }

        private void TypeList_SelectType(object sender, SelectionChangedEventArgs e)
        {
            if (TypeList.SelectedItem != null)
            {
                _process.SelectedType(TypeList.SelectedItem);
                if (_process.ActiveItem.ItemProperty != null)
                    FillProperties();
            }
        }



        private void AddRarety(object sender, RoutedEventArgs e)
        {
            if (RaretyName.Text != null)
                _process.AddRareties(RaretyName.Text);
            else
                _process.AddRareties();
            FillRaretyList();
            RaretyName.Clear();
        }

        private void DeleteRarety(object sender, RoutedEventArgs e)
        {
            if (RaretyList.SelectedItem != null)
            _process.RemoveRarety();
            FillRaretyList();
        }

        private void UpdateRarety(object sender, RoutedEventArgs e)
        {

        }

        private void RaretyList_SelectRarety(object sender, SelectionChangedEventArgs e)
        {
            if (RaretyList.SelectedItem != null)
            {
                _process.SelectedRarety(RaretyList.SelectedItem);
            }
        }



        private void AddPropertiesButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void UpdatePropertiesButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
