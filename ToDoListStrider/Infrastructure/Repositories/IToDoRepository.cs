﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListStrider.Domain;

namespace ToDoListStrider.Infrastructure.Repositories
{
    public interface IToDoRepository
    {
        Task Add(ToDoItem item);
        Task Update(ToDoItem item);
        Task<List<ToDoItem>> GetByUserId(int userId);
        Task<ToDoItem> GetById(int id);
        Task<List<ToDoItem>> GetByUserIdAndStatus(int userId, bool isDone); // New method to get tasks by user ID and status
    }
}
