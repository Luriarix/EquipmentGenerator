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
using System.Text.RegularExpressions;

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
            if (ItemName.Text != "")
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
            if (ItemName.Text != "")
            {
                if (ItemName.Text != _process.ActiveItem.ItemName)
                {
                    _process.UpdateItem(_process.ActiveItem.ItemId, ItemName.Text);
                    FillItemList();
                    ItemName.Clear();
                }
                else
                {
                    if (_process.ActiveItem.ItemType != _process.ActiveType || _process.ActiveItem.CommonItemRarety != _process.ActiveRarety)
                    {
                        _process.UpdateItem(_process.ActiveItem.ItemId, _process.ActiveItem.ItemName);
                    }
                }
            }
            FillItemList();
        }

        private void ItemList_SelectItem(object sender, SelectionChangedEventArgs e)
        {
            if (ItemList.SelectedItem != null)
            {
                _process.SelectedItem(ItemList.SelectedItem);
                _process.SelectedType(_process.ActiveItem.ItemId);
                _process.SelectedRarety(_process.ActiveItem.RaretyForeignId);
                _process.SelectedProperties(_process.ActiveItem.PropertyForeignId);
                ItemName.Text = _process.ActiveItem.ItemName;

                if (_process.ActiveItem.RaretyForeignId != 0)
                {
                    _process.SelectedRarety(_process.ActiveItem.RaretyForeignId);
                    RaretyName.Text = _process.ActiveRarety.Rarety;
                    RaretyMax.Text = _process.ActiveRarety.MaxPoints.ToString();
                }
                else
                {
                    RaretyName.Clear();
                    RaretyMax.Clear();
                }

                if (_process.ActiveItem.TypeForeignId != 0)
                {
                    _process.SelectedType(_process.ActiveItem.TypeForeignId);
                    TypeName.Text = _process.ActiveType.Type;
                }
                else
                    TypeName.Clear();

                if (_process.ActiveItem.PropertyForeignId != 0)
                {
                    _process.SelectedProperties(_process.ActiveItem.PropertyForeignId);
                    DurabilityAmount.Text = _process.ActiveProperties.Durability.ToString();
                    AttackAmount.Text = _process.ActiveProperties.Attack.ToString();
                    DefenceAmount.Text = _process.ActiveProperties.Defence.ToString();
                    StrengthAmount.Text = _process.ActiveProperties.Strength.ToString();
                    DexterityAmount.Text = _process.ActiveProperties.Dexterity.ToString();
                    IntelligenceAmount.Text = _process.ActiveProperties.Inteligence.ToString();
                }
                else
                {
                    DurabilityAmount.Clear();
                    AttackAmount.Clear();
                    DefenceAmount.Clear();
                    StrengthAmount.Clear();
                    DexterityAmount.Clear();
                    IntelligenceAmount.Clear();
                }
            }
        }


        private void AddType(object sender, RoutedEventArgs e)
        {
            if (TypeName.Text != "")
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
            if (TypeName.Text != "")
            {
                _process.UpdateType(_process.ActiveType.TypeId, TypeName.Text);
            }
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
            if (RaretyName.Text != "" && RaretyMax.Text != "")
                _process.AddRareties(RaretyName.Text, Int32.Parse(RaretyMax.Text));
            else if (RaretyName.Text != "")
                _process.AddRareties(RaretyName.Text, 0);
            else
                _process.AddRareties();
            FillRaretyList();
            RaretyName.Clear();
            RaretyMax.Clear();
        }

        private void DeleteRarety(object sender, RoutedEventArgs e)
        {
            if (RaretyList.SelectedItem != null)
            _process.RemoveRarety();
            FillRaretyList();
        }

        private void UpdateRarety(object sender, RoutedEventArgs e)
        {
            if (RaretyName.Text != "" && RaretyMax.Text != "")
                _process.UpdateRarety(_process.ActiveRarety.RaretyId, RaretyName.Text, Int32.Parse(RaretyMax.Text));
            else if (RaretyName.Text != "")
                _process.UpdateRarety(_process.ActiveRarety.RaretyId, RaretyName.Text, 0);
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
            _process.UpdateProperties(_process.ActiveItem.PropertyForeignId, Int32.Parse(DurabilityAmount.Text), Int32.Parse(AttackAmount.Text), Int32.Parse(DefenceAmount.Text), Int32.Parse(StrengthAmount.Text), Int32.Parse(DexterityAmount.Text), Int32.Parse(IntelligenceAmount.Text));
            FillItemList();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
