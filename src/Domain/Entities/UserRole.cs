using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalCA.Domain.Entities;

[Table("UserRole")]
public class UserRole
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}
