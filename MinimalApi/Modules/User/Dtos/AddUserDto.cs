namespace MinimalApi.Modules.User.Dtos;

public record AddUserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}