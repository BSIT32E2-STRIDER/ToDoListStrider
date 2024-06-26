﻿using System.Threading.Tasks;
using ToDoListStrider.Domain;
namespace ToDoListStrider.Application
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task<User> Register(User user);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
        Task Add(User user);
    }
}
