using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using FoodOrder.Model;

namespace FoodOrder.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private FoodOrderDatabaseEntities _database;
        private CollectionViewSource _usersViewSource;

        public UsersView()
        {
            InitializeComponent();

            var roles = new List<string>
                            {UserRole.Clerk.ToString(), UserRole.Manager.ToString(), UserRole.Owner.ToString()};
            roleColumn.ItemsSource = roles;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;

            _database = new FoodOrderDatabaseEntities();
            _usersViewSource = (CollectionViewSource) (FindResource("usersViewSource"));
            _usersViewSource.Source = _database.Users.Execute(MergeOption.AppendOnly);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _database.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Please make sure you have entered a value for each column and set the appropriate role for the user.");
            }
        }
    }
}