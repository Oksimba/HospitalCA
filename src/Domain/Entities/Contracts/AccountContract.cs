namespace HospitalCA.Domain.Entities.Contracts;
public class AccountContract
{
    public int Id { get; set; }
    public string Login { get; set; }
    public List<Role> Roles { get; set; }
}