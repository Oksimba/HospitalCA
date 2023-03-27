using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalCA.Domain.Entities;

[Table("Role")]
public class Role
{
    [Column("RoleID")]
    public int Id { get; set; }
    [Column("RoleName")]
    public string Name { get; set; }
}

