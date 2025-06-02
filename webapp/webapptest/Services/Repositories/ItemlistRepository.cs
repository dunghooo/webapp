using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webapptest.DTOs.ItemListDTO;
using webapptest.Models;
using webapptest.Services.Interfaces;

namespace webapptest.Services.Repositories
{

    public class ItemlistRepository : Itemlist
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ItemlistRepository(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<AddItemListDto> AddDetailToOrder(AddItemListDto addItem)
        {
            var mapitem = _mapper.Map<TblOrderDetail>(addItem);
            var item = await _db.TblItemLists.FirstOrDefaultAsync(i => i.ItemId == mapitem.ItemId);
            
            if (item == null)
            {
                return null;
            }
            if(addItem.Quantity > 0 && addItem.Amount > 0)
            {
                addItem.Price = (double)(addItem.Amount / (decimal)addItem.Quantity);
            }
            else
            {
                addItem.Amount = (decimal)(addItem.Quantity * addItem.Price);
            }
            _db.TblOrderDetails.Add(mapitem);
            await _db.SaveChangesAsync();
            return _mapper.Map<AddItemListDto>(mapitem);
        }

        public async Task<IEnumerable<TblItemList>> GetItemListByItemid(string ItemId)
        {
            var result = await _db.TblItemLists.Where(x => x.ItemId == ItemId).ToListAsync();
            return result;
        }
    }
}
