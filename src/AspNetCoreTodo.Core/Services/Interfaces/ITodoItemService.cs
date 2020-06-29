using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Core.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();
    }
}
