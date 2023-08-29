using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO;

namespace Capstone.DAO
{
    public class ListSqlDAO : IListDao
    {
        private readonly string connectionString;

        public ListSqlDAO(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public List<List> GetListsByUserID(int user_id)
        {
            List<List> list = new List<List>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM list WHERE user_id = @user_id;", conn);
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        List _list = GetListFromReader(reader);
                        list.Add(_list);
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }

            return list;
        }

        public List GetListByListID(int list_id)
        {
            List list = new List();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM list WHERE list_id = @list_id", conn);
                    cmd.Parameters.AddWithValue("@list_id", list_id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read())
                    {
                        list = GetListFromReader(reader);
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception("Something went wrong");
            }
            return list;
        }

        public bool CreateList(List list)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    int newID;
                    using (SqlCommand idCmd = new SqlCommand("SELECT MAX(list_id) FROM list;", conn))
                    {
                        object result = idCmd.ExecuteScalar();
                        newID = result == DBNull.Value ? 1 : Convert.ToInt32(result) + 1;
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO list (list_id, name, user_id) " +
                        "VALUES (@list_id, @name, @user_id);", conn);

                    cmd.Parameters.AddWithValue("@list_id", newID);
                    cmd.Parameters.AddWithValue("@name", list.Name);
                    cmd.Parameters.AddWithValue("@user_id", list.User_ID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected == 1;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteList(int list_id)
        {
            int rowsAffected;

            // Instantiate TodoSqlDAO
            TodoSqlDAO todoDao = new TodoSqlDAO(connectionString);

            // Call GetTodosByListID method
            List<Todo> todos = todoDao.GetTodosByListID(list_id);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Delete todos associated with the list
                    using (SqlCommand todoCmd = new SqlCommand("DELETE FROM todo WHERE list_id = @list_id", conn))
                    {
                        todoCmd.Parameters.AddWithValue("@list_id", list_id);
                        todoCmd.ExecuteNonQuery();
                    }

                    // Delete the list itself
                    SqlCommand cmd = new SqlCommand("DELETE FROM list WHERE list_id = @list_id", conn);
                    cmd.Parameters.AddWithValue("@list_id", list_id);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                return rowsAffected == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List GetListFromReader(SqlDataReader reader)
        {
            List list = new List();

            list.List_ID = Convert.ToInt32(reader["list_id"]);
            list.Name = Convert.ToString(reader["name"]);
            list.User_ID = Convert.ToInt32(reader["user_id"]);

            return list;
        }
    }
}
