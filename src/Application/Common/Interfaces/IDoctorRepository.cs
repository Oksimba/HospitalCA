using HospitalCA.Domain.Entities;

namespace HospitalCA.Application.Common.Interfaces;

public interface IDoctorRepository
{
    IEnumerable<Doctor> Get();
    Doctor Get(int id);
    void Create(Doctor doctor);
    void Update(int id, Doctor doctor);
    Doctor Delete(int id);
}
