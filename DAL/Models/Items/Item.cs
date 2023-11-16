using BnLog.DAL.Models.Entity;

namespace BnLog.DAL.Models.Items
{
    public class Item
    //Non entity elements for linking  addons to main entitys
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedData { get; set; } = DateTime.Now.ToUniversalTime();
        // к чему привязываемся
        public itType ItemType { get; set; } =itType.Undefinend;
        public Guid? ItemId { get; set; } = null;
        public List<ItemOption> ItemOption { get; set; } = new List<ItemOption>();
        public List<ItemResurce> ItemResurce { get; set; } = new List<ItemResurce>(); 
    }
}
