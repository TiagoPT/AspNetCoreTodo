using System.Collections.Generic;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Web.Models
{
    public class TodoViewModel
    {
        public IEnumerable<TodoItem> Items { get; set; }
    }
}
