namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Description { get; private set; }

        public Guid UserId { get; private set; }

        public virtual User User { get; private set; }

        public Account() { }

        public Account(string description, Guid userId)
        {
            Description = description;
            UserId = userId;
        }
    }
}
