namespace Application.Users.Queries
{
    public record UserDto
    {
        public Guid Id { get; set; }
        public string UserCreatedName { get; set; }
    }
}
