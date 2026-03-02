namespace TeamPortal.Api.Dtos;

public class UserResponseDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string FamilyName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role{ get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedOnUtc { get; set; }

}
