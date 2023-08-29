using System.Collections.Generic;

namespace Capstone.Models
{
    public interface IListDao
    {
        List<List> GetListsByUserID(int user_id);
        List GetListByListID(int list_id);
        bool CreateList(List list);
        bool DeleteList(int list_id);

    }
}
