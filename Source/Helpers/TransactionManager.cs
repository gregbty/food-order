using FoodOrder.Helper;
using FoodOrder.Model;

namespace FoodOrder.Helpers
{
    internal static class TransactionManager
    {
        private static Order _order;

        public static void SetTransaction(Order order)
        {
            _order = order;
            PageManager.ShowTransactionView();
        }

        public static Order GetOrder()
        {
            return _order;
        }

        public static void EndOrder()
        {
            _order = null;
            PageManager.ShowOrderView(true);
        }
    }
}