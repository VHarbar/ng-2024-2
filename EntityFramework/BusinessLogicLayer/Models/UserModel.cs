namespace BusinessLogicLayer.Models
{
    public record UserModel
    {
        public Guid Id { get; set; }
        public string UserCreatedName { get; set; }
    }
}
