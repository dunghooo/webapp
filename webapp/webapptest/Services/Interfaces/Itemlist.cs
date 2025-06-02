using webapptest.DTOs.ItemListDTO;
using webapptest.Models;

namespace webapptest.Services.Interfaces
{
    public interface Itemlist
    {
        Task<IEnumerable<TblItemList>> GetItemListByItemid(string ItemId);

        Task<AddItemListDto> AddDetailToOrder(AddItemListDto addItem);
    }
}
