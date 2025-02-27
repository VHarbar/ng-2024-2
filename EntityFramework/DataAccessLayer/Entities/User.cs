namespace DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public Guid? AccountId { get; set; }

        public virtual Account? Account { get; set; }
    }
}
