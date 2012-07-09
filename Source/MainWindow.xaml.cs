using System.Windows;
using FoodOrder.Helper;
using FoodOrder.Model;

namespace FoodOrder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly FoodOrderDatabaseEntities Database = new FoodOrderDatabaseEntities();

        public MainWindow()
        {
            InitializeComponent();

            UserManager.SetDatabaseContext(Database);
            PageManager.SetContent(PageManager.View.Login);
        }
    }
}