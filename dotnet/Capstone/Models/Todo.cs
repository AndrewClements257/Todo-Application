namespace Capstone.Models
{
    public class Todo
    {
        public int Todo_ID { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int List_ID { get; set; }

        public Todo(int todo_ID, string name, bool isComplete, int list_ID)
        {
            Todo_ID = todo_ID;
            Name = name;
            IsComplete = isComplete;
            List_ID = list_ID;
        }

        public Todo() { }
    }
}
