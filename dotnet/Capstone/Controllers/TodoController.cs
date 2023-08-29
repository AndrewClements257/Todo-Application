using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoDao todoDao;

        public TodoController(ITodoDao _todoDao)
        {
            this.todoDao = _todoDao;
        }

        [HttpGet("{list_id}")]
        public List<Todo> GetTodosByListID(int list_id)
        {
            return todoDao.GetTodosByListID(list_id);
        }

        [HttpPost]
        public bool CreateTodo(Todo todo)
        {
            return todoDao.CreateTodo(todo);
        }

        [HttpPut]
        public bool MarkTodoDone(Todo todo)
        {
            return todoDao.MarkTodoDone(todo);
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 48fa4ebe9f7bdb86c3afed4439c12c7f51eba555
        [HttpGet("Completed/{list_id}")]
        public List<Todo> GetCompletedTodosByListID(int list_id)
        {
            return todoDao.GetCompletedTodosByListID(list_id);
        }

<<<<<<< HEAD
=======
>>>>>>> 56236b7102f8fc2eb871b6e9f5ce06d0a83abdaf
=======
>>>>>>> 48fa4ebe9f7bdb86c3afed4439c12c7f51eba555
        [HttpDelete("{todo_id}")]
        public bool DeleteTodo(int todo_id)
        {
            return todoDao.DeleteTodo(todo_id);
        }
    }
}
