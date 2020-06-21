using System;
using System.Collections.Generic;
using System.Linq;
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
using EquipmentDatabase;
using EquipmentGenerator;
using System.Text.RegularExpressions;


namespace EquipmentGeneratorWPF
{
    /// <summary>
    /// Interaction logic for Unique.xaml
    /// </summary>
    public partial class Unique : Page
    {

        public Random _i = new Random();

        public Unique()
        {
            InitializeComponent();
            FillItemList();
            _process.CleanUpUnique();
        }

        private Processes _process = new Processes();

        public void FillItemList()
        {
            ItemList.ItemsSource = _process.ReadUniqueItemList();
        }
        public void FillProperties()
        {
            DurabilityAmount.Text = _process.UniqueItems.UniqueItemProperty.Durability.ToString();
            StrengthAmount.Text = _process.UniqueItems.UniqueItemProperty.Strength.ToString();
            DexterityAmount.Text = _process.UniqueItems.UniqueItemProperty.Dexterity.ToString();
            IntelligenceAmount.Text = _process.UniqueItems.UniqueItemProperty.Inteligence.ToString();
            AttackAmount.Text = _process.UniqueItems.UniqueItemProperty.Attack.ToString();
            DefenceAmount.Text = _process.UniqueItems.UniqueItemProperty.Defence.ToString();
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
            RaretyName.Text = _process.UniqueItems.UniqueItemRarety.Rarety;
            RaretyMax.Text = _process.UniqueItems.UniqueItemRarety.MaxPoints.ToString();
        }
        public void ClearRarety()
        {
            RaretyName.Clear();
            RaretyMax.Clear();
        }
        public void FillItemType()
        {
            TypeName.Text = _process.UniqueItems.UniqueItemType.Type;
        }

        private void ItemAdd(object sender, RoutedEventArgs e)
        {
                _process.AddUniques(ItemName.Text);
            FillItemList();
            ItemName.Clear();
        }

        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (ItemList.SelectedItem != null)
                _process.RemoveItem();
            FillItemList();
        }
        private void ItemList_SelectItem(object sender, SelectionChangedEventArgs e)
        {
            if (ItemList.SelectedItem != null)
            {
                _process.SelectUnique(ItemList.SelectedItem);
                ItemName.Text = _process.UniqueItems.UniqueItemName;

                if (_process.UniqueItems.UniqueItemRarety != null)
                {
                    FillItemRarety();
                }
                else
                {
                    ClearRarety();
                }

                if (_process.UniqueItems.UniqueItemType != null)
                {
                    TypeName.Text = _process.UniqueItems.UniqueItemType.Type;
                }
                else
                {
                    TypeName.Clear();
                }

                if (_process.UniqueItems.UniqueItemProperty != null)
                {
                    _process.SelectedProperties(_process.UniqueItems.UniqueItemProperty);
                    FillProperties();
                }
                else
                {
                    ClearProperties();
                }
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void GenerateItem(object sender, RoutedEventArgs e)
        {
            _process.RandomItem();
            FillItemRarety();
            FillItemType();
            FillProperties();
        }

        


    }
}
