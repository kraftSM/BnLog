﻿namespace BnLog.DAL.Models.Items
{
    public class ItemOption
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedData { get; set; } = DateTime.Now.ToUniversalTime();
        public Guid ItemId { get; set; }
        // тип опции
        public itOptionType TypeId { get; set; } = itOptionType.Undefinend;
        public string Type { get; set; } = string.Empty;
        // значение опции
        public string strVal { get; set; } = string.Empty;
        public int? intVal { get; set; } = null;
    }
}