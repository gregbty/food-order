using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using FoodOrder.Helper;
using FoodOrder.Helpers;
using FoodOrder.Model;

namespace FoodOrder.Views
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : UserControl
    {
        private readonly Order _order;
        private int _orderStep;
        private double _changeToGive;

        public TransactionView()
        {
            InitializeComponent();

            _order = TransactionManager.GetOrder();

            carryoutBtn.IsEnabled = false;
            cashBtn.IsEnabled = false;
            TransitionToStep(true);
        }

        private void TransitionToStep(bool next = false)
        {
            if (next)
                _orderStep++;
            else
                _orderStep--;

            backBtn.IsEnabled = _orderStep != 1;
            backBtn.Visibility = _orderStep != 1 ? Visibility.Visible : Visibility.Hidden;
            orderBtn.Visibility = _orderStep != 4 ? Visibility.Visible : Visibility.Hidden;
            cancelBtn.Visibility = _orderStep != 4 ? Visibility.Visible : Visibility.Hidden;
            carryoutBtn.Visibility = Visibility.Hidden;
            deliveryBtn.Visibility = Visibility.Hidden;
            cashBtn.Visibility = Visibility.Hidden;
            payNowBtn.Visibility = Visibility.Hidden;
            creditBtn.Visibility = Visibility.Hidden;
            continueBtn.Content = "Continue >";

            switch (_orderStep)
            {
                case 1:
                    {
                        GenerateTransaction();
                        tabControl.SelectedItem = summaryTab;
                        continueBtn.IsEnabled = true;
                    }
                    break;
                case 2:
                    {
                        carryoutBtn.Visibility = Visibility.Visible;
                        deliveryBtn.Visibility = Visibility.Visible;
                        continueBtn.IsEnabled = deliveryBtn.IsEnabled;
                        tabControl.SelectedItem = deliveryBtn.IsEnabled ? summaryTab : deliveryTab;
                        CheckIfDeliveryTextBoxesAreComplete();
                    }
                    break;
                case 3:
                    {
                        cashBtn.Visibility = Visibility.Visible;
                        payNowBtn.Visibility = Visibility.Hidden;
                        creditBtn.Visibility = Visibility.Visible;
                        continueBtn.IsEnabled = false;
                        tabControl.SelectedItem = cashBtn.IsEnabled ? creditTab : cashTab;
                        CheckIfTransactionTextBoxesAreComplete();
                    }
                    break;
                case 4:
                    {
                        backBtn.Visibility = Visibility.Hidden;
                        continueBtn.Visibility = Visibility.Hidden;
                        orderBtn.Content = "Return to Orders";
                        orderBtn.Visibility = Visibility.Visible;
                        tabControl.SelectedItem = receiptTab;
                        SaveTransaction();
                    }
                    break;
            }
        }

        private void GenerateTransaction()
        {
            richTextBox1.Clear();
            richTextBox1.AppendText("Order No: 012312321312321");
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);

            if (_order.Sandwiches.Count > 0)
            {
                richTextBox1.AppendText("Sandwiches:");
                richTextBox1.AppendText(Environment.NewLine);
                for (int i = 0; i < _order.Sandwiches.Count; i++)
                {
                    Sandwich sandwich = _order.Sandwiches[i];
                    richTextBox1.AppendText(string.Format("Sandwich {0}  (Size: {1}, Quantity: {2})", (i + 1), sandwich.Size, sandwich.Quantity));
                    richTextBox1.AppendText(Environment.NewLine);

                    richTextBox1.AppendText("Bread - ");
                    richTextBox1.AppendText(sandwich.Bread.name + string.Format("  ({0:C})", (sandwich.Size == SubSize.SixInch ? sandwich.Bread.price / 2 : sandwich.Bread.price)));

                    richTextBox1.AppendText(Environment.NewLine);
                    richTextBox1.AppendText("Cheese - ");
                    richTextBox1.AppendText(sandwich.Cheese.name + string.Format("  ({0:C})", sandwich.Cheese.price));

                    richTextBox1.AppendText(Environment.NewLine);
                    richTextBox1.AppendText("Meats: ");
                    richTextBox1.AppendText(Environment.NewLine);
                    foreach (OrderItem meat in sandwich.Meats)
                    {
                        richTextBox1.AppendText("      " + meat.name + string.Format("  ({0}@{1:C})",meat.quantity , meat.price));
                        richTextBox1.AppendText(Environment.NewLine);
                    }

                    richTextBox1.AppendText("Extras: ");
                    richTextBox1.AppendText(Environment.NewLine);
                    foreach (OrderItem veggie in sandwich.Veggies)
                    {
                        richTextBox1.AppendText("      " + veggie.name);
                        richTextBox1.AppendText(Environment.NewLine);
                    }

                    if (_order.Sandwiches.Count > 1)
                        richTextBox1.AppendText(Environment.NewLine);
                }

                richTextBox1.AppendText("--------------------------------------");
                richTextBox1.AppendText(Environment.NewLine);
            }

            if (_order.Drinks.Count > 0)
            {
                richTextBox1.AppendText("Drinks:");
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText(Environment.NewLine);

                foreach (OrderItem drink in _order.Drinks)
                {
                    richTextBox1.AppendText(drink.name + string.Format("  ({0}@{1:C})", drink.quantity, drink.price));
                    richTextBox1.AppendText(Environment.NewLine);
                }

                richTextBox1.AppendText("--------------------------------------");
                richTextBox1.AppendText(Environment.NewLine);
            }

            if (_order.Chips.Count > 0)
            {
                richTextBox1.AppendText("Chips:");
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText(Environment.NewLine);

                foreach (OrderItem chip in _order.Chips)
                {
                    richTextBox1.AppendText(chip.name + string.Format("  ({0}@{1:C})", chip.quantity, chip.price));
                    richTextBox1.AppendText(Environment.NewLine);
                }

                richTextBox1.AppendText("--------------------------------------");
                richTextBox1.AppendText(Environment.NewLine);
            }

            if (_order.Cookies.Count > 0)
            {
                richTextBox1.AppendText("Cookies:");
                richTextBox1.AppendText(Environment.NewLine);
                richTextBox1.AppendText(Environment.NewLine);

                foreach (OrderItem cookie in _order.Cookies)
                {
                    richTextBox1.AppendText(cookie.name + string.Format("  ({0}@{1:C})", cookie.quantity, cookie.price));
                    richTextBox1.AppendText(Environment.NewLine);
                }

                richTextBox1.AppendText("--------------------------------------");
                richTextBox1.AppendText(Environment.NewLine);
            }

            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);

            double subTotal = _order.Total;
            double taxes = subTotal*0.06;
            double total = subTotal + taxes;

            var totals = new StringBuilder();
            totals.AppendLine("Sub Total: " + string.Format("{0:C}", subTotal));
            totals.AppendLine("Taxes: " + string.Format("{0:C}", taxes));
            totals.AppendLine("Total: " + string.Format("{0:C}", total));
            
            richTextBox1.AppendText(totals.ToString());
            totalTxt.Text = String.Format("{0:C}", subTotal + taxes);
        }

        private void SaveTransaction()
        {
            var transaction = new Transaction { id = Guid.NewGuid(), finalprice = _order.Total + (_order.Total * 0.06), paymentoption = PaymentOption.Cash.ToString(), time = DateTime.Now };
            if (!creditBtn.IsEnabled)
            {
                transaction.paymentoption = PaymentOption.Credit.ToString();
                transaction.cardexpiration = expirationTxt.Text;
                transaction.cardholdername = holderNameTxt.Text;
                transaction.cardnumber = cardNumberTxt.Text;
            }

            var database = new FoodOrderDatabaseEntities();
            database.Transactions.AddObject(transaction);
            database.SaveChanges();

            var transactionItems = new List<TransactionItem>();
            foreach (var sandwich in _order.Sandwiches)
            {
                AddOrUpdateTransactionItem(transaction.id, sandwich.Bread, ref transactionItems);
                AddOrUpdateTransactionItem(transaction.id, sandwich.Cheese, ref transactionItems);

                foreach (var meat in sandwich.Meats)
                {
                    AddOrUpdateTransactionItem(transaction.id, meat, ref transactionItems);
                }

                foreach (var veggie in sandwich.Veggies)
                {
                    AddOrUpdateTransactionItem(transaction.id, veggie, ref transactionItems);
                }
            }

            foreach (var chip in _order.Chips)
            {
                AddOrUpdateTransactionItem(transaction.id, chip, ref transactionItems);
            }

            foreach (var cookie in _order.Cookies)
            {
                AddOrUpdateTransactionItem(transaction.id, cookie, ref transactionItems);
            }

            foreach (var drink in _order.Drinks)
            {
                AddOrUpdateTransactionItem(transaction.id, drink, ref transactionItems);
            }

            transactionItems.ForEach(t=>database.TransactionItems.AddObject(t));
            database.SaveChanges();
        }

        private void AddOrUpdateTransactionItem(Guid id, OrderItem orderItem, ref List<TransactionItem> transactionItems)
        {
            var item = new TransactionItem
                           {
                               id = Guid.NewGuid(),
                               name = orderItem.name,
                               price = orderItem.price,
                               quantity = orderItem.quantity,
                               transactionid = id
                           };
            transactionItems.Add(item);
        }

        private void orderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_orderStep != 4)
                PageManager.ShowOrderView();
            else
                TransactionManager.EndOrder();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            TransactionManager.EndOrder();
        }

        private void cashBtn_Click(object sender, RoutedEventArgs e)
        {
            cashBtn.IsEnabled = false;
            creditBtn.IsEnabled = true;
            CheckIfTransactionTextBoxesAreComplete();
            tabControl.SelectedItem = cashTab;
        }

        private void creditBtn_Click(object sender, RoutedEventArgs e)
        {
            cashBtn.IsEnabled = true;
            creditBtn.IsEnabled = false;
            CheckIfTransactionTextBoxesAreComplete();
            tabControl.SelectedItem = creditTab;
        }

        private void carryoutBtn_Click(object sender, RoutedEventArgs e)
        {
            carryoutBtn.IsEnabled = false;
            deliveryBtn.IsEnabled = true;
            CheckIfDeliveryTextBoxesAreComplete();
            tabControl.SelectedItem = cashBtn.IsEnabled ? creditTab : summaryTab;
        }

        private void deliveryBtn_Click(object sender, RoutedEventArgs e)
        {
            carryoutBtn.IsEnabled = true;
            deliveryBtn.IsEnabled = false;
            CheckIfDeliveryTextBoxesAreComplete();
            tabControl.SelectedItem = deliveryTab;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_orderStep == 0) return;
            TransitionToStep();
        }

        private void continueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_orderStep == 4) return;

            TransitionToStep(true);
        }

        private void deliveryTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfDeliveryTextBoxesAreComplete();
        }

        private void CheckIfDeliveryTextBoxesAreComplete()
        {
            bool completed = (!String.IsNullOrEmpty(addressTxt.Text) && !String.IsNullOrEmpty(zipcodeTxt.Text) &&
                              !String.IsNullOrEmpty(cityTxt.Text)) || deliveryBtn.IsEnabled;
            continueBtn.IsEnabled = completed;
        }

        private void CheckIfTransactionTextBoxesAreComplete()
        {
            if (!cashBtn.IsEnabled)
            {
                var rgx = new Regex(@"[^0-9.]");
                string strTotalRemaining = totalTxt.Text;
                strTotalRemaining = rgx.Replace(strTotalRemaining, "");

                double totalRemaining = String.IsNullOrEmpty(strTotalRemaining)
                                            ? _order.Total + (_order.Total)*0.06
                                            : Convert.ToDouble(strTotalRemaining);

                string strTenderedAmount = tenderedTxt.Text;
                strTenderedAmount = rgx.Replace(strTenderedAmount, "");

                double tenderedAmount = String.IsNullOrEmpty(strTenderedAmount)
                                            ? 0
                                            : Convert.ToDouble(strTenderedAmount);

                _changeToGive = tenderedAmount - totalRemaining;
                payNowBtn.Visibility = _changeToGive>= 0? Visibility.Visible : Visibility.Hidden;
                payNowBtn.IsEnabled = _changeToGive >= 0;
            }
            else if (!creditBtn.IsEnabled)
            {
                continueBtn.IsEnabled = !String.IsNullOrEmpty(holderNameTxt.Text) &&
                                        !String.IsNullOrEmpty(cardNumberTxt.Text) &&
                                        !String.IsNullOrEmpty(expirationTxt.Text);
            }
        }

        private void transactionTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckIfTransactionTextBoxesAreComplete();
        }

        private void payNowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_changeToGive > 0)
            {
                MessageBox.Show(string.Format("Change to give: {0:C}", _changeToGive));
            }

            continueBtn.Visibility = Visibility.Visible;
            payNowBtn.Visibility = Visibility.Hidden;
            TransitionToStep(true);
        }
    }
}