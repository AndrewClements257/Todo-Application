namespace Capstone.Models
{
    public class List
    {
        public int List_ID { get; set; }
        public string Name { get; set; }
        public int User_ID { get; set; }

        public List(int listId, string name, int userId)
        {
            List_ID = listId;
            Name = name;
            User_ID = userId;
        }

        public List() { }
    }
}
