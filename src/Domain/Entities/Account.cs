namespace HospitalCA.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public List<Role> Roles { get; set; }
}
