﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListStrider.Domain;

namespace ToDoListStrider.Application
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetPendingToDoItemsByUserId(int userId);
        Task<List<ToDoItem>> GetCompletedToDoItemsByUserId(int userId);
        Task AddToDoItem(ToDoItem item);
        Task UpdateToDoItem(ToDoItem item);
        Task<ToDoItem> GetById(int id);
        Task Update(ToDoItem item);


    }
}
