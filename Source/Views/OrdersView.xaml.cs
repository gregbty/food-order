using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using FoodOrder.Helpers;
using FoodOrder.Model;

namespace FoodOrder.Views
{
    /// <summary>
    /// Interaction logic for OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        private readonly List<OrderItem> _chips = new List<OrderItem>();
        private readonly List<OrderItem> _cookies = new List<OrderItem>();
        private readonly FoodOrderDatabaseEntities _database = new FoodOrderDatabaseEntities();
        private readonly List<OrderItem> _drinks = new List<OrderItem>();
        private readonly Order _order = new Order();
        private int _orderStep;
        private Sandwich _sandwich = new Sandwich();
        private ItemType _type;

        public OrdersView()
        {
            InitializeComponent();
            CalculateTotal();
            CreateNewSandwich();

            transactionBtn.IsEnabled = false;
        }

        private void CreateNewSandwich()
        {
            _type = ItemType.Sandwich;
            _orderStep = 0;
            _sandwich = new Sandwich();

            sixInchBtn.IsChecked = true;
            TransitionToSandwichStep(true);
        }

        private void TransitionToSandwichStep(bool next = false)
        {
            if (next)
                _orderStep++;
            else
                _orderStep--;

            sixInchBtn.Visibility = footLongBtn.Visibility = _orderStep > 1 ? Visibility.Hidden : Visibility.Visible;
            listView.Focusable = _orderStep != 1;

            infoLbl.Content = String.Empty;
            listView.ItemsSource = null;
            listView.SelectionMode = SelectionMode.Single;
            backBtn.IsEnabled = _orderStep != 1;
            backBtn.Visibility = _orderStep != 1 ? Visibility.Visible : Visibility.Hidden;
            nextBtn.IsEnabled = _orderStep == 1;

            switch (_orderStep)
            {
                case 1:
                    {
                        infoLbl.Content = "Choose the sandwich size:";
                        nextBtn.Content = "Breads >";
                        sixInchBtn.IsChecked = _sandwich.Size == SubSize.SixInch;
                        footLongBtn.IsChecked = _sandwich.Size != SubSize.SixInch;
                    }
                    break;
                case 2:
                    {
                        infoLbl.Content = "Choose a type of bread:";
                        backBtn.Content = "< Size";
                        nextBtn.Content = "Cheeses >";

                        listView.ItemsSource = _database.OrderItems.Where(t => t.type == "Bread");
                        listView.SelectedItem = _sandwich.Bread;
                    }
                    break;
                case 3:
                    {
                        infoLbl.Content = "Choose a type of cheese:";
                        backBtn.Content = "< Breads";
                        nextBtn.Content = "Meats >";

                        listView.ItemsSource = _database.OrderItems.Where(t => t.type == "Cheese");
                        listView.SelectedItem = _sandwich.Cheese;
                    }
                    break;
                case 4:
                    {
                        infoLbl.Content = "Choose the meats:";
                        backBtn.Content = "< Cheeses";
                        nextBtn.Content = "Extras >";
                        listView.SelectionMode = SelectionMode.Multiple;

                        listView.ItemsSource = _database.OrderItems.Where(t => t.type == "Meat");
                        _sandwich.Meats.ForEach(t => listView.SelectedItems.Add(t));
                    }
                    break;
                case 5:
                    {
                        infoLbl.Content = "Choose the extras:";
                        backBtn.Content = "< Meats";
                        nextBtn.Content = "Add to Order >";
                        listView.SelectionMode = SelectionMode.Multiple;

                        listView.ItemsSource = _database.OrderItems.Where(t=>t.type == "Veggie");
                        _sandwich.Veggies.ForEach(t => listView.SelectedItems.Add(t));
                    }
                    break;
            }
        }

        private void AddItemToSandwich()
        {
            switch (_orderStep)
            {
                case 1:
                    _sandwich.Size = sixInchBtn.IsChecked == true ? SubSize.SixInch : SubSize.FootLong;
                    break;
                case 2:
                    _sandwich.Bread = listView.SelectedItem as OrderItem;
                    break;
                case 3:
                    _sandwich.Cheese = listView.SelectedItem as OrderItem;
                    break;
                case 4:
                    _sandwich.Meats.Clear();
                    _sandwich.Meats.AddRange(listView.SelectedItems.Cast<OrderItem>());
                    break;
                case 5:
                    _sandwich.Veggies.Clear();
                    _sandwich.Veggies.AddRange(listView.SelectedItems.Cast<OrderItem>());
                    break;
            }
        }

        private void AddDrinks()
        {
            _type = ItemType.Drink;
            _orderStep = 0;
            _drinks.Clear();
            TransitionToDrinkStep(true);
        }

        private void TransitionToDrinkStep(bool next = false)
        {
            if (next)
                _orderStep++;
            else
                _orderStep--;

            sixInchBtn.Visibility = footLongBtn.Visibility = Visibility.Hidden;

            infoLbl.Content = String.Empty;
            listView.ItemsSource = null;
            listView.SelectionMode = SelectionMode.Multiple;
            backBtn.IsEnabled = _orderStep != 1;
            backBtn.Visibility = _orderStep != 1 ? Visibility.Visible : Visibility.Hidden;
            nextBtn.IsEnabled = _orderStep == 1;

            switch (_orderStep)
            {
                case 1:
                    {
                        infoLbl.Content = "Choose the drinks (bottled only):";
                        nextBtn.Content = "Add to Order >";

                        listView.ItemsSource = _database.OrderItems.Where(t => t.type == "Drink");
                        _drinks.ForEach(t => listView.SelectedItems.Add(t));
                    }
                    break;
            }
        }

        private void AddChips()
        {
            _type = ItemType.Chips;
            _orderStep = 0;
            _chips.Clear();
            TransitionToChipsStep(true);
        }

        private void TransitionToChipsStep(bool next = false)
        {
            if (next)
                _orderStep++;
            else
                _orderStep--;

            sixInchBtn.Visibility = footLongBtn.Visibility = Visibility.Hidden;

            infoLbl.Content = String.Empty;
            listView.ItemsSource = null;
            listView.SelectionMode = SelectionMode.Multiple;
            backBtn.IsEnabled = _orderStep != 1;
            backBtn.Visibility = _orderStep != 1 ? Visibility.Visible : Visibility.Hidden;
            nextBtn.IsEnabled = _orderStep == 1;

            switch (_orderStep)
            {
                case 1:
                    {
                        infoLbl.Content = "Choose the chips:";
                        nextBtn.Content = "Add to Order >";

                        listView.ItemsSource = _database.OrderItems.Where(t => t.type == "Chip");
                        _chips.ForEach(t => listView.SelectedItems.Add(t));
                    }
                    break;
            }
        }

        private void AddCookies()
        {
            _type = ItemType.Cookie;
            _orderStep = 0;
            _cookies.Clear();
            TransitionToCookiesStep(true);
        }

        private void TransitionToCookiesStep(bool next = false)
        {
            if (next)
                _orderStep++;
            else
                _orderStep--;

            sixInchBtn.Visibility = footLongBtn.Visibility = Visibility.Hidden;

            infoLbl.Content = String.Empty;
            listView.ItemsSource = null;
            listView.SelectionMode = SelectionMode.Multiple;
            backBtn.IsEnabled = _orderStep != 1;
            backBtn.Visibility = _orderStep != 1 ? Visibility.Visible : Visibility.Hidden;
            nextBtn.IsEnabled = _orderStep == 1;

            switch (_orderStep)
            {
                case 1:
                    {
                        infoLbl.Content = "Choose the cookie type:";
                        nextBtn.Content = "Add to Order >";

                        listView.ItemsSource = _database.OrderItems.Where(t => t.type == "Cookie");
                        _cookies.ForEach(t => listView.SelectedItems.Add(t));
                    }
                    break;
            }
        }

        private void CalculateTotal()
        {
            treeView.Items.Clear();
            _order.Sandwiches.ForEach(t => treeView.Items.Add(t));
            _order.Chips.ForEach(t => treeView.Items.Add(t));
            _order.Cookies.ForEach(t => treeView.Items.Add(t));
            _order.Drinks.ForEach(t => treeView.Items.Add(t));

            double subTotal = _order.Total;
            double taxes = subTotal * 0.06;

            taxLbl.Visibility = _order.Total <= 0 ? Visibility.Hidden : Visibility.Visible;
            taxesLbl.Visibility = _order.Total <= 0 ? Visibility.Hidden : Visibility.Visible;

            taxesLbl.Content = String.Format("{0:C}", taxes);
            amountLbl.Content = String.Format("{0:C}", subTotal + taxes);
            transactionBtn.IsEnabled = _order.IsCompleted;
        }

        private void sandwichesBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateNewSandwich();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_orderStep == 0) return;

            switch (_type)
            {
                case ItemType.Sandwich:
                    TransitionToSandwichStep();
                    break;
                case ItemType.Drink:
                    TransitionToDrinkStep();
                    break;
                case ItemType.Chips:
                    TransitionToChipsStep();
                    break;
                case ItemType.Cookie:
                    TransitionToCookiesStep();
                    break;
            }
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (_type)
            {
                case ItemType.Sandwich:
                    {
                        AddItemToSandwich();
                        if (_orderStep == 5)
                        {
                            _order.Sandwiches.Add(_sandwich);
                            CalculateTotal();
                            CreateNewSandwich();
                        }
                        else
                        {
                            TransitionToSandwichStep(true);
                        }
                    }
                    break;
                case ItemType.Drink:
                    {
                        if (_orderStep == 1)
                        {
                            foreach (var orderItem in listView.SelectedItems.Cast<OrderItem>())
                            {
                                var drink = _order.Drinks.SingleOrDefault(t => t.id == orderItem.id);
                                if (drink == null)
                                {
                                    _order.Drinks.Add(orderItem);
                                }
                                else
                                {
                                    drink.quantity++;
                                }
                            }

                            CalculateTotal();
                            AddDrinks();
                        }
                    }
                    break;
                case ItemType.Chips:
                    {
                        if (_orderStep == 1)
                        {
                            foreach (var orderItem in listView.SelectedItems.Cast<OrderItem>() )
                            {
                                var chips = _order.Chips.SingleOrDefault(t => t.id == orderItem.id);
                                if (chips == null)
                                {
                                    _order.Chips.Add(orderItem);
                                }
                                else
                                {
                                    chips.quantity++;
                                }
                            }
                            
                            CalculateTotal();
                            AddChips();
                        }
                    }
                    break;
                case ItemType.Cookie:
                    {
                        if (_orderStep == 1)
                        {
                            foreach (var orderItem in listView.SelectedItems.Cast<OrderItem>())
                            {
                                var cookie = _order.Cookies.SingleOrDefault(t => t.id == orderItem.id);
                                if (cookie == null)
                                {
                                    _order.Cookies.Add(orderItem);
                                }
                                else
                                {
                                    cookie.quantity++;
                                }
                            }

                            CalculateTotal();
                            AddCookies();
                        }
                    }
                    break;
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_type == ItemType.Sandwich)
            {
                nextBtn.IsEnabled = _orderStep > 3
                                        ? listView.SelectedItems.Count > 0
                                        : listView.SelectedItems.Count == 1;
            }
            else
            {
                nextBtn.IsEnabled = listView.SelectedItems.Count > 0;
            }
        }

        private void chipsBtn_Click(object sender, RoutedEventArgs e)
        {
            AddChips();
        }

        private void cookiesBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCookies();
        }

        private void drinksBtn_Click(object sender, RoutedEventArgs e)
        {
            AddDrinks();
        }

        private void transactionBtn_Click(object sender, RoutedEventArgs e)
        {
            TransactionManager.SetTransaction(_order);
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            transactionBtn.IsEnabled = _order.IsCompleted;
        }

        private void orderListMenu_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem == null) return;

            if (menuItem == editMenuItem)
            {
                var sandwich = treeView.SelectedItem as Sandwich;
                if (sandwich != null)
                {
                    _order.Sandwiches.Remove(sandwich);

                    _type = ItemType.Sandwich;
                    _orderStep = 0;
                    _sandwich = sandwich;
                    TransitionToSandwichStep(true);
                    return;
                }
            }
            else if (menuItem == removeMenuItem)
            {
                var sandwich = treeView.SelectedItem as Sandwich;
                if (sandwich != null)
                {
                    _order.Sandwiches.Remove(sandwich);
                }

                var orderItem = treeView.SelectedItem as OrderItem;
                if (orderItem != null)
                {
                    switch (orderItem.type)
                    {
                        case "Chip":
                            _order.Chips.Remove(orderItem);
                            break;
                        case "Cookie":
                            _order.Cookies.Remove(orderItem);
                            break;
                        case "Drink":
                            _order.Drinks.Remove(orderItem);
                            break;

                    }
                }
            }

            CalculateTotal();
        }

        private void orderListMenu_ContextMenuOpened(object sender, RoutedEventArgs routedEventArgs)
        {
            editMenuItem.IsEnabled = treeView.SelectedItem is Sandwich;
            removeMenuItem.IsEnabled = treeView.SelectedItem != null;
        }

        #region Nested type: ItemType

        private enum ItemType
        {
            Sandwich,
            Drink,
            Cookie,
            Chips
        }

        #endregion

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            CalculateTotal();
        }
    }
}