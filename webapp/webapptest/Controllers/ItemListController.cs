using Microsoft.AspNetCore.Mvc;
using webapptest.DTOs.ItemListDTO;
using webapptest.Models;
using webapptest.Services.Interfaces;

namespace webapptest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemListController : Controller
    {
        private readonly Itemlist _itemlist;
        public ItemListController(Itemlist itemlist)
        {
            _itemlist = itemlist;
        }
        [HttpGet("get-Itemlist-by-id")]
        public async Task<IActionResult> GetItemListByItemid(string ItemId)
        {
            var result = await _itemlist.GetItemListByItemid(ItemId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add-order-detail")]

        public async Task<IActionResult> AddDetailToOrder([FromBody] AddItemListDto orderDetail)
        {
            var result = await _itemlist.AddDetailToOrder(orderDetail);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
