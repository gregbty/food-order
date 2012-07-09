using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using FoodOrder.Model;

namespace FoodOrder.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        private FoodOrderDatabaseEntities _database;
        private CollectionViewSource _transactionsViewSource;
        private List<Transaction> _transactions;

        public ReportsView()
        {
            InitializeComponent();

            comboBox1.Items.Add(ReportType.Financial);
            comboBox1.Items.Add(ReportType.Inventory);
            comboBox1.SelectedIndex = 0;

            fromPicker.SelectedDate = DateTime.Now;
            toPicker.SelectedDate = DateTime.Now;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _database = new FoodOrderDatabaseEntities();
            _transactionsViewSource = (CollectionViewSource) (FindResource("transactionsViewSource"));
            _transactions = _database.Transactions.ToList();

            RefreshList();
        }

        private void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            fromPicker.DisplayDateEnd = toPicker.SelectedDate;
            toPicker.DisplayDateStart = fromPicker.SelectedDate;

            DateTime? toSelectedDate = toPicker.SelectedDate;
            DateTime? fromSelectedDate = fromPicker.SelectedDate;
            if (toSelectedDate == null || fromSelectedDate == null) return;

            _transactionsViewSource.Source =
                _transactions.Where(
                    t => t.time.Date >= fromSelectedDate.Value.Date && t.time.Date <= toSelectedDate.Value.Date);
        }

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Report generated");
        }
    }
}