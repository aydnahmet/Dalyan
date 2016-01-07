namespace Dalyan.Entities.Models
{
    public class CurrentUser
    {

        public int UserID
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public int UserType
        {
            get; set;
        }

        public int CompanyId
        {
            get; set;
        }

        public string CompanyName
        {
            get; set;
        }

        public string IpAddress
        {
            get; set;
        }
    }
}
