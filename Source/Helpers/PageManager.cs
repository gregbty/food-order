using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FoodOrder.Model;
using FoodOrder.Views;

namespace FoodOrder.Helper
{
    internal static class PageManager
    {
        #region View enum

        public enum View
        {
            Login,
            Home
        }

        #endregion

        private static readonly MainWindow Window = (MainWindow) Application.Current.MainWindow;
        private static readonly Dictionary<View, UserControl> Controls = new Dictionary<View, UserControl>();

        private static UserControl GetView(View view)
        {
            if (!Controls.ContainsKey(view))
            {
                switch (view)
                {
                    case View.Login:
                        Controls.Add(view, new LoginView());
                        break;
                    case View.Home:
                        Controls.Add(view, new HomeView());
                        break;
                }
            }

            return Controls[view];
        }

        public static void ShowOrderView(bool destroy = false)
        {
            var homeView = (HomeView)Controls[View.Home];
            homeView.SetContent(homeView.GetView(HomeView.View.Orders, destroy));
        }

        public static void ShowTransactionView()
        {
            var homeView = (HomeView) Controls[View.Home];
            homeView.SetContent(homeView.GetView(HomeView.View.Transaction, true));
        }

        public static void SetContent(View view, bool loggedout = false)
        {
            if (loggedout)
                Controls.Clear();

            Window.Content = GetView(view);
        }
    }
}