using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for Item_Managemet.xaml
    /// </summary>
    public partial class Item_Managemet : Page
    {
        public Item_Managemet()
        {
            InitializeComponent();
            FillItemList();
            FillRaretyList();
            FillTypeList();
            //_process.CleanUp();
        }
        private Processes _process = new Processes();

       

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
            DurabilityAmount.Text = _process.ActiveItem.ItemProperty.Durability.ToString();
            StrengthAmount.Text = _process.ActiveItem.ItemProperty.Strength.ToString();
            DexterityAmount.Text = _process.ActiveItem.ItemProperty.Dexterity.ToString();
            IntelligenceAmount.Text = _process.ActiveItem.ItemProperty.Inteligence.ToString();
            AttackAmount.Text = _process.ActiveItem.ItemProperty.Attack.ToString();
            DefenceAmount.Text = _process.ActiveItem.ItemProperty.Defence.ToString();
        }
        public void ClearProperties()
        {
            DurabilityAmount.Clear();
            AttackAmount.Clear();
            DefenceAmount.Clear();
            StrengthAmount.Clear();
            DexterityAmount.Clear();
            IntelligenceAmount.Clear();
        }

        public void FillItemRarety()
        {
            RaretyName.Text = _process.ActiveItem.CommonItemRarety.Rarety;
            RaretyMax.Text = _process.ActiveItem.CommonItemRarety.MaxPoints.ToString();
        }
        public void FillRarety()
        {
            RaretyName.Text = _process.ActiveRarety.Rarety;
            RaretyMax.Text = _process.ActiveRarety.MaxPoints.ToString();
        }
        public void ClearRarety()
        {
            RaretyName.Clear();
            RaretyMax.Clear();
        }

        private void ItemAdd(object sender, RoutedEventArgs e)
        {
            if (ItemName.Text != "")
                _process.AddItem(ItemName.Text);
            else
                _process.AddItem();
            FillItemList();
            ItemName.Clear();
            //_process.SelectedItem(null);
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
                    _process.UpdateItem(ItemName.Text);
                    ItemName.Clear();
                }
                else
                {
                    if (_process.ActiveItem.ItemType != _process.ActiveType || _process.ActiveItem.CommonItemRarety != _process.ActiveRarety)
                    {
                        _process.UpdateItem(_process.ActiveItem.ItemName);
                    }
                }
            }
            _process.SelectedRarety(null);
            _process.SelectedType(null);
            FillItemList();
        }

        private void ItemList_SelectItem(object sender, SelectionChangedEventArgs e)
        {
            if (ItemList.SelectedItem != null)
            {
                _process.SelectedItem(ItemList.SelectedItem);
                ItemName.Text = _process.ActiveItem.ItemName;

                if (_process.ActiveItem.CommonItemRarety != null)
                {
                    FillItemRarety();
                }
                else
                {
                    ClearRarety();
                }

                if (_process.ActiveItem.ItemType != null)
                {
                    TypeName.Text = _process.ActiveItem.ItemType.Type;
                }
                else
                {
                    TypeName.Clear();
                }

                if (_process.ActiveItem.ItemProperty != null)
                {
                    _process.SelectedProperties(_process.ActiveItem.ItemProperty);
                    FillProperties();
                }
                else
                {
                    ClearProperties();
                }
                _process.SelectedType(null);
                _process.SelectedRarety(null);
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
            TypeName.Text = "";
            FillTypeList();
        }

        private void UpdateType(object sender, RoutedEventArgs e)
        {
            if (TypeName.Text != "" | TypeName.Text != _process.ActiveType.Type)
            {
                _process.UpdateType(TypeName.Text);
            }
            FillTypeList();
        }

        private void TypeList_SelectType(object sender, SelectionChangedEventArgs e)
        {
            if (TypeList.SelectedItem != null)
            {
                _process.SelectedType(TypeList.SelectedItem);
                TypeName.Text = _process.ActiveType.Type;
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
            ClearRarety();
        }

        private void DeleteRarety(object sender, RoutedEventArgs e)
        {
            if (RaretyList.SelectedItem != null)
                _process.RemoveRarety();
            ClearRarety();
            FillRaretyList();
        }

        private void UpdateRarety(object sender, RoutedEventArgs e)
        {
            if (RaretyName.Text != _process.ActiveRarety.Rarety && RaretyMax.Text != _process.ActiveRarety.MaxPoints.ToString())
                _process.UpdateRarety(RaretyName.Text, Int32.Parse(RaretyMax.Text));

            else
            {
                if (RaretyName.Text != _process.ActiveRarety.Rarety)
                    _process.UpdateRarety(RaretyName.Text, _process.ActiveRarety.MaxPoints);

                if (RaretyMax.Text != _process.ActiveRarety.MaxPoints.ToString())
                    _process.UpdateRarety(_process.ActiveRarety.Rarety, Int32.Parse(RaretyMax.Text));
            }
            FillRaretyList();
        }

        private void RaretyList_SelectRarety(object sender, SelectionChangedEventArgs e)
        {
            if (RaretyList.SelectedItem != null)
            {
                _process.SelectedRarety(RaretyList.SelectedItem);
                FillRarety();
            }
        }



        private void AddPropertiesButton_Click(object sender, RoutedEventArgs e)
        {
            _process.UpdateProperties(Int32.Parse(DurabilityAmount.Text), Int32.Parse(AttackAmount.Text), Int32.Parse(DefenceAmount.Text), Int32.Parse(StrengthAmount.Text), Int32.Parse(DexterityAmount.Text), Int32.Parse(IntelligenceAmount.Text));
            FillItemList();
            ClearProperties();
            ClearRarety();
            TypeName.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

