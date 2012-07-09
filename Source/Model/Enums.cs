using System.ComponentModel;

namespace FoodOrder.Model
{
    public enum UserRole
    {
        Clerk,
        Owner,
        Manager
    }

    public enum ReportType
    {
        Financial,
        Inventory
    }

    public enum SubSize
    {
        [Description("6 inches")]
        SixInch,

        [Description("12 inches (1 foot)")]
        FootLong
    }

    public enum DrinkSize
    {
        Small,
        Medium,
        Large
    }

    public enum PaymentOption
    {
        Credit,
        Cash
    }
}