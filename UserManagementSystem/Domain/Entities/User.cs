namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }

        public List<Account> Accounts { get; private set; } = new();

        public User() { }

        public User(string userName, List<Account>? accounts = null)
        {
            UserName = userName;
            Accounts = accounts;
        }
    }
}
