using System.ComponentModel.DataAnnotations;

namespace apbd_lab12.Models.Security;

public class User
{
    [Key]

    public int Id { get; set; }
    [MaxLength(100)]
    public string Username { get; set; }
    [MaxLength(100)]
    public string PasswordHash { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}