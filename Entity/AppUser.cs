﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entity;

public class AppUser
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(250, ErrorMessage = "{0} is too long")]
    public string Username { get; set; } = string.Empty;
    [Required]
    [StringLength(250, ErrorMessage = "{0} is too long")]
    [EmailAddress(ErrorMessage = "{0} is not valid")]
    public string EmailAddress { get; set; } = string.Empty;
    [Required]
    [StringLength(20, ErrorMessage = "{0} is too long")]
    public string Password { get; set; } = string.Empty;
    [Required]
    public DateTime RegisterDate { get; set; } = DateTime.Now;

    #region Navigation Properties

    [JsonIgnore]
    public ICollection<UserAddress>? UserAddresses { get; set; }

    #endregion
}