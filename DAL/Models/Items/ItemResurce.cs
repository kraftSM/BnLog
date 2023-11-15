namespace BnLog.DAL.Models.Items
{
    //enum ItemResurceType { undefine = 0, test }; //?? или в Repo забросить. Там определим
    public class ItemResurce
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedData { get; set; } = DateTime.Now.ToUniversalTime();
        public Guid ItemId { get; set; }
        // тип ресурса
        public int? TypeId { get; set; } = 0;
        public string Type { get; set; } = string.Empty;
        // значение ресурса
        public string strVal { get; set; } = string.Empty;
        public int? intVal { get; set; } = null;
    }
}
