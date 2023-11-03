namespace BnLog.DLL.Models.Items
{
    public class Item
    //Non entity elements for linking  addons to main entitys
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedData { get; set; } = DateTime.Now.ToUniversalTime();
        // к чему привязываемся
        public int? ItemType { get; set; } = null;
        public Guid? ItemId { get; set; } = null;
    }
}
