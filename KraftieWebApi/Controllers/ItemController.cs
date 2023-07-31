using KraftieWebApi.Repositories;
using KraftieWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MySqlHelper.QueryHelper;

namespace KraftieWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IRepository<Item> _itemRespository;
        public ItemController(IRepository<Item> itemRepository)
        {
            _itemRespository = itemRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Item> items = _itemRespository.Get();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            Item item = _itemRespository.Get(id);

            return Ok(item);
        }

        
        [HttpPost("update")]
        public IActionResult UpdateItems(IEnumerable<PostItemViewModel> itemViewModel)
        {
            foreach (var itemVm in itemViewModel)
            {
                Item item = new(itemVm);
                _itemRespository.Insert(item);
            }


            return Ok();
        }
    }
}
