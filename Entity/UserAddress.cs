using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Entity;

public class UserAddress
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int AppUserId { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "{0} is too long")]
    public string PhoneNumber { get; set; } = string.Empty;
    [AllowNull]
    [StringLength(50, ErrorMessage = "{0} is too long")]
    public string? ZipCode { get; set; } = string.Empty;
    [AllowNull]
    [StringLength(50, ErrorMessage = "{0} is too long")]
    public string? Longitude { get; set; } = string.Empty;
    [AllowNull]
    [StringLength(50, ErrorMessage = "{0} is too long")]
    public string? Attitude { get; set; } = string.Empty;
    [Required]
    [StringLength(500, ErrorMessage = "{0} is too long")]
    public string Address { get; set; } = string.Empty;

    #region Navigation Properties

    [JsonIgnore]
    public AppUser? User { get; set; }

    #endregion
}