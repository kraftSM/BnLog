﻿using System.ComponentModel.DataAnnotations;



namespace BnLog.VAL.Request.Security

{
    public class RoleCreateRequest
    {
        [Required(ErrorMessage = "Поле Название обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Уровень доступа обязательно для заполнения")]
        [DataType(DataType.Text)]
        [Display(Name = "Уровень доступа", Prompt = "Уровень")]
        public int SecurityLvl { get; set; }
    }
}
