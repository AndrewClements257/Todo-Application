using Capstone.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class TodoSqlDAO : ITodoDao
    {
        private readonly string connectionString;

        public TodoSqlDAO(string dbconnectionString)
        {
            connectionString = dbconnectionString;
        }

        public List<Todo> GetTodosByListID(int list_id)
        {
            List<Todo> list = new List<Todo>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM todo WHERE list_id = @list_id  AND complete = 0;", conn);

                    cmd.Parameters.AddWithValue("@list_id", list_id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Todo todo = GetTodoFromReader(reader);
                        list.Add(todo);
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
            return list;
        }

        public List<Todo> GetCompletedTodosByListID(int list_id)
        {
            List<Todo> list = new List<Todo>();
            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM todo WHERE list_id = @list_id AND complete = 1;", conn);
                    cmd.Parameters.AddWithValue("@list_id", list_id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Todo todo = GetTodoFromReader(reader);
                        list.Add(todo);
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
            return list;
        }

        public bool CreateTodo(Todo todo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Genereate a new todo ID
                    int newID;
                    using (SqlCommand idCmd = new SqlCommand("SELECT MAX(todo_id) FROM todo", conn))
                    {
                        object result = idCmd.ExecuteScalar();
                        newID = result == DBNull.Value ? 1 : Convert.ToInt32(result) + 1;
                    }

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO todo (todo_id,name,complete,list_id) " +
                        "VALUES (@todo_id, @name, @complete, @list_id);", conn))
                    {
                        cmd.Parameters.AddWithValue("@todo_id", newID);
                        cmd.Parameters.AddWithValue("@name", todo.Name);
                        cmd.Parameters.AddWithValue("@complete", todo.IsComplete);
                        cmd.Parameters.AddWithValue("@list_id", todo.List_ID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        bool success = rowsAffected == 1;
                        return success;
                    }

                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool MarkTodoDone(Todo todo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE todo SET complete = @complete WHERE todo_id = @todo_id;", conn);
                    cmd.Parameters.AddWithValue("@complete", todo.IsComplete);
                    cmd.Parameters.AddWithValue("@todo_id", todo.Todo_ID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    bool success = rowsAffected == 1;
                    return success;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTodo(int todo_id)
        {
            int rowsAffected;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM todo WHERE todo_id = @todo_id", conn);
                    cmd.Parameters.AddWithValue("@todo_id", todo_id);

                    rowsAffected = cmd.ExecuteNonQuery();
                }
                return rowsAffected == 1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private Todo GetTodoFromReader(SqlDataReader reader)
        {
            Todo todo = new Todo()
            {
                Todo_ID = Convert.ToInt32(reader["todo_id"]),
                Name = Convert.ToString(reader["name"]),
                IsComplete = Convert.ToBoolean(reader["complete"]),
                List_ID = Convert.ToInt32(reader["list_id"])

            };
            return todo;

        }
    }
}
