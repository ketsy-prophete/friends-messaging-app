using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace myApi.Models;

public class User
{
    [JsonIgnore]
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Required]
    [DisplayName("User Name")]
    public string? UserName { get; set; }

    [Required]
    public string? Password { get; set; }
}

//TODO: add more properties to User