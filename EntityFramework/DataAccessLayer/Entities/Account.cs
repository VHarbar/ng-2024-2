namespace DataAccessLayer.Entities
{
    public class Account : BaseEntity
    {
        public string Description { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
