using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IListDao listDao;

        public ListController(IListDao _listDao)
        {
            listDao = _listDao;
        }

        [HttpGet("{user_id}")]
        public List<List> GetListsByUserID(int user_id)
        {
            return listDao.GetListsByUserID(user_id);
        }

        [HttpGet("Current/{list_id}")]
        public List GetListByListID(int list_id)
        {
            return listDao.GetListByListID(list_id);
        }

        [HttpPut]
        public bool CreateList(List list)
        {
            return listDao.CreateList(list);
        }

        [HttpDelete("{list_id}")]
        public bool DeleteList(int list_id)
        {
            return listDao.DeleteList(list_id);
        }
    }
}
