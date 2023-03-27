using HospitalCA.Application.Common.Interfaces;
using HospitalCA.Domain.Entities;
using HospitalCA.Infrastructure.Persistence;

namespace HospitalCA.Infrastructure.Repositories;

public class DoctorRepository: IDoctorRepository
{
    private readonly DoctorDbContext context;

    public DoctorRepository(DoctorDbContext context)
    {
        this.context = context;
    }
    public IEnumerable<Doctor> Get()
    {
        return context.Doctors;
    }

    public Doctor Get(int id)
    {
        return context.Doctors.Find(id);
    }

    public void Create(Doctor doctor)
    {
        context.Doctors.Add(doctor);
        context.SaveChanges();
    }

    public void Update(int id, Doctor doctor)
    {
        Doctor currentDoctor = Get(id);
        currentDoctor.Login = doctor.Login;
        currentDoctor.FirstName = doctor.FirstName;
        currentDoctor.LastName = doctor.LastName;
        currentDoctor.Email = doctor.Email;
        context.Doctors.Update(currentDoctor);
        context.SaveChanges();
    }

    public Doctor Delete(int id)
    {
        Doctor doctor = Get(id);
        if(doctor != null)
        {
            context.Doctors.Remove(doctor);
            context.SaveChanges();
        }
        return doctor;
    }

}
