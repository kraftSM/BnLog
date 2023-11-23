namespace BnLog.VAL.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public int? ErrCode { get; set; } = 500;
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}