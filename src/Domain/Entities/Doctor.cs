using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalCA.Domain.Entities;

[Table("Doctor")]
public class Doctor
{
    [Column("DoctorId")]
    public int Id { get; set; }
    public string Login { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
