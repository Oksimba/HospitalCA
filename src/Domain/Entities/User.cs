using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalCA.Domain.Entities;

[Table("User")]
public class User
{
    [Column("UserId")]
    public int Id { get; set; }
    public string Login { get; set; }
    public string HashPassword { get; set; }
}
