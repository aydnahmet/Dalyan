namespace Dalyan.Entities.Enumerations
{
    /// <summary>
    /// Client Error Message
    /// </summary>
    public static class ClientErrorMessage
    {
        private static string _success = "Your transaction has been completed successfully.";
        private static string _error = "Error. Please try again.";
        public static string Success()
        {
            return _success;
        }

        public static string Error()
        {
            return _error;
        }
    }
}
