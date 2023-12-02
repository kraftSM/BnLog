using System.ComponentModel.DataAnnotations;


namespace BnLog.VAL.Request.Security

{
    public class RoleEditRequest
    {
        //private const int cntName_01 = 10;
        //private const string errMsgCntName_01 = @"Please enter correct name (Len =< {cntName_01}";
      
        public Guid Id { get; set; }

        [DataType(DataType.Text)]
        [MinLength(4, ErrorMessage = "Длина роли должна быть не менее  4 символов")]
        [MaxLength(10, ErrorMessage = "Длина роли должна быть не более 10 символов")]
        [Required(ErrorMessage = "Поле [Название] обязательно для заполнения")]
        [Display(Name = "Название", Prompt = "Название")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Поле Уровень доступа обязательно для заполнения")]
        [Range(0, 3, ErrorMessage = "Введите правильное значение [0...3] ")] 
        [Display(Name = "Уровень доступа", Prompt = "Уровень")]
        public int? SecurityLvl { get; set; } = null;
    }
}
