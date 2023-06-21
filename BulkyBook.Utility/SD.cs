namespace BulkyBook.Utility
{
    public static class SD
    {
        public const string Role_User_Indi = "Individual";
        public const string Role_User_Comp = "Company";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

        // PENDING when item is bought
        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        //pending when not recieve money
        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";

        //when company buy this will be applied
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        // this will be applied when user is broke
        public const string PaymentStatusRejected = "Rejected";


        public const string SessionCart = "SessionShoppingCart";
    }
}