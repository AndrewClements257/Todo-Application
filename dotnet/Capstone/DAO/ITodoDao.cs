using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface ITodoDao
    {
        List<Todo> GetTodosByListID(int list_id);
        bool CreateTodo(Todo todo);
        bool MarkTodoDone(Todo todo);
        bool DeleteTodo(int todo_id);
        List<Todo> GetCompletedTodosByListID(int todo_id);
    }
}
