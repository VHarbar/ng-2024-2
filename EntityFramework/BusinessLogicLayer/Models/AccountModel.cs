namespace BusinessLogicLayer.Models
{
    public record AccountModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public UserModel User { get; set; }
    }
}
