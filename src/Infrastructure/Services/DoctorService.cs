using HospitalCA.Application.Common.Interfaces;
using HospitalCA.Domain.Entities;
using HospitalCA.Infrastructure.Repositories;

namespace HospitalCA.Infrastructure.Services;

public class DoctorService: IDoctorService
{
    IDoctorRepository doctorRepository;
    public DoctorService(IDoctorRepository doctorRepository)
    {
        this.doctorRepository = doctorRepository;
    }
    public IEnumerable<Doctor> Get()
    {
        //return doctorRepository.Get();
        return FakeDB.Doctors.OrderBy(s => s.Id);
    }

    public Doctor Get(int id)
    {
        //return doctorRepository.Get(id);
        return FakeDB.Doctors.FirstOrDefault(s => s.Id == id);
    }

    public void Create(Doctor doctor)
    {
        //doctorRepository.Create(doctor);
        FakeDB.Doctors.Add(doctor);
    }

    public void Update(int id, Doctor updatedDoctor)
    {

        //var doctor = doctorRepository.Get(id);
        var doctor = FakeDB.Doctors.FirstOrDefault(s => s.Id == id);

        if (doctor != null)
        {
            //doctorRepository.Update(id, updatedDoctor);
            FakeDB.Doctors.Remove(doctor);
            FakeDB.Doctors.Add(updatedDoctor);
        }
    }

    public Doctor Delete(int id)
    {
        //return doctorRepository.Delete(id);
        var doctor = FakeDB.Doctors.FirstOrDefault(s => s.Id == id);

        if (doctor != null)
        {
            //doctorRepository.Update(id, updatedDoctor);
            FakeDB.Doctors.Remove(doctor);
        }
        return doctor;
    }
}
