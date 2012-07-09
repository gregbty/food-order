using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FoodOrder.Helper;
using FoodOrder.Model;

namespace FoodOrder.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        #region View enum

        public enum View
        {
            Orders,
            Users,
            Reports,
            Transaction
        }

        #endregion

        private readonly Dictionary<View, UserControl> _controls = new Dictionary<View, UserControl>();
        private readonly User _user;

        public HomeView()
        {
            InitializeComponent();
            _user = UserManager.GetUser();

            statusLbl.Content = "Hello " + _user.firstname + " " + _user.lastname + ", Role: " + _user.role;

            var role = (UserRole) Enum.Parse(typeof (UserRole), _user.role, true);
            switch (role)
            {
                case UserRole.Owner:
                    SetContent(GetView(View.Users));
                    break;
                case UserRole.Manager:
                case UserRole.Clerk:
                    SetContent(GetView(View.Orders));
                    break;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as MainWindow;
            if (window == null) return;
            window.Background = Background;
        }

        public void SetContent(UserControl control)
        {
            mainContent.Content = control;
        }

        public UserControl GetView(View view, bool destroy = false)
        {
            if (destroy)
                _controls.Remove(view);

            ordersBtn.IsEnabled = view != View.Transaction;
            usersBtn.IsEnabled = view != View.Transaction;
            reportsBtn.IsEnabled = view != View.Transaction;
            logOffBtn.IsEnabled = true;

            var role = (UserRole) Enum.Parse(typeof (UserRole), _user.role, true);
            usersBtn.Visibility = role == UserRole.Owner && view != View.Transaction
                                      ? Visibility.Visible
                                      : Visibility.Hidden;
            reportsBtn.Visibility = role != UserRole.Clerk && view != View.Transaction
                                        ? Visibility.Visible
                                        : Visibility.Hidden;
            ordersBtn.Visibility = view != View.Transaction
                                      ? Visibility.Visible
                                      : Visibility.Hidden;


            if (!_controls.ContainsKey(view))
            {
                switch (view)
                {
                    case View.Orders:
                        _controls.Add(view, new OrdersView());
                        break;
                    case View.Users:
                        _controls.Add(view, new UsersView());
                        break;
                    case View.Reports:
                        _controls.Add(view, new ReportsView());
                        break;
                    case View.Transaction:
                        _controls.Add(view, new TransactionView());
                        break;
                }
            }

            return _controls[view];
        }

        private void logOffBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!UserManager.IsLoggedIn()) return;
            UserManager.RemoveCookie();
        }

        private void usersBtn_Click(object sender, RoutedEventArgs e)
        {
            SetContent(GetView(View.Users));
        }

        private void ordersBtn_Click(object sender, RoutedEventArgs e)
        {
            SetContent(GetView(View.Orders));
        }

        private void reportsBtn_Click(object sender, RoutedEventArgs e)
        {
            SetContent(GetView(View.Reports));
        }
    }
}