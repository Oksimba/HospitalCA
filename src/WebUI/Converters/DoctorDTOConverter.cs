using HospitalCA.Domain.Entities;
using HospitalCA.Domain.Entities.Contracts;

namespace MentorshipProject.Converters;

public static class DoctorDTOConverter
{
    public static IEnumerable<Doctor> ToDoctors(this IEnumerable<DoctorContract> items)
    {
        return items
           .SelectMany(item => new[] { item.ToDoctor() });
    }

    public static IEnumerable<DoctorContract> ToDoctorContracrs(this IEnumerable<Doctor> items)
    {
        return items
           .SelectMany(item => new[] { item.ToDoctorContract() });
    }
    public static Doctor ToDoctor(this DoctorContract item)
    {
        if (item == null)
            return null;

        return new Doctor
        {
            Id = item.Id,
            Login = item.Login,
            FirstName = item.FirstName,
            LastName = item.LastName,
            Email = item.Email
        };
    }
    public static DoctorContract ToDoctorContract(this Doctor item)
    {
        if (item == null)
            return null;

        return new DoctorContract
        {
            Id = item.Id,
            Login = item.Login,
            FirstName = item.FirstName,
            LastName = item.LastName,
            Email = item.Email
        };
    }
}
