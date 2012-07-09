using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FoodOrder.Helper;
using FoodOrder.Model;

namespace FoodOrder.Views
{
    /// <summary>
    /// Interaction logic for LogingView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();

            loginBtn.IsEnabled = false;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this) as MainWindow;
            if (window == null) return;
            window.Background = Background;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var entries = new FoodOrderDatabaseEntities())
            {
                var users = entries.Users;
                var user =
                    users.SingleOrDefault(t => t.username == usernameTxt.Text && t.password == passwordTxt.Text);
                if (user == null)
                {
                    errorLbl.Visibility = Visibility.Visible;
                }
                else
                {
                    UserManager.SetCookie(user);

                    usernameTxt.Text = String.Empty;
                    passwordTxt.Text = String.Empty;
                }
            }
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = sender as TextBox;
            if (txt == null) return;

            if (txt == usernameTxt)
            {
                loginBtn.IsEnabled = !String.IsNullOrEmpty(usernameTxt.Text) && !String.IsNullOrEmpty(passwordTxt.Text);
            }
            else if (txt == passwordTxt)
            {
                loginBtn.IsEnabled = !String.IsNullOrEmpty(usernameTxt.Text) && !String.IsNullOrEmpty(passwordTxt.Text);
            }
        }
    }
}
