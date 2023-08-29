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
<<<<<<< HEAD
<<<<<<< HEAD
        List<Todo> GetCompletedTodosByListID(int todo_id);
=======
>>>>>>> 56236b7102f8fc2eb871b6e9f5ce06d0a83abdaf
=======
        List<Todo> GetCompletedTodosByListID(int todo_id);
>>>>>>> 48fa4ebe9f7bdb86c3afed4439c12c7f51eba555
    }
}
