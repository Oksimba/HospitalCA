using HospitalCA.Application.Common.Interfaces;
using HospitalCA.Domain.Entities;
using HospitalCA.Infrastructure.Persistence;

namespace HospitalCA.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext context;

    public UserRepository(UserDbContext context)
    {
        this.context = context;
    }
    public IEnumerable<User> Get()
    {
        return context.Users;
    }

    public User Get(int id)
    {
        return context.Users.Find(id);
    }

    public void Create(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void Update(int id, User user)
    {
        User currentUser = Get(id);
        currentUser.Login = user.Login;
        currentUser.HashPassword = user.HashPassword;
        context.Users.Update(currentUser);
        context.SaveChanges();
    }

    public User Delete(int id)
    {
        User user = Get(id);
        if (user != null)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
        return user;
    }
}