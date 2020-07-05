using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Core.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync(string userId);
        Task<bool> AddItemAsync(TodoItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}
