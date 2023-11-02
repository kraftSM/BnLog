namespace BnLog.Repo.Models.Items
{
    public class ItemOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedData { get; set; } = DateTime.Now.ToUniversalTime();
        public Guid ItemId { get; set; }
        // тип опции
        public int? TypeId { get; set; } = 0;
        public string Type { get; set; } = string.Empty;
        // значение опции
        public string strVal { get; set; } = string.Empty;
        public int? intVal { get; set; } = null;
    }
}
