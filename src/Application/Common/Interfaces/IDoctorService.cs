using HospitalCA.Domain.Entities;

namespace HospitalCA.Application.Common.Interfaces;

public interface IDoctorService
{
    public IEnumerable<Doctor> Get();

    public Doctor Get(int id);

    public void Create(Doctor doctor);

    public void Update(int id, Doctor updatedDoctor);

    public Doctor Delete(int id);
}
