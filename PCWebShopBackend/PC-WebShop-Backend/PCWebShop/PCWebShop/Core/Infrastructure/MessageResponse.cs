using Microsoft.AspNetCore.Mvc.RazorPages;
using PCWebShop.Core.Infrastructure.Enums;

namespace PCWebShop.Core.Infrastructure
{
    public class MessageResponse
    {
        public virtual ExceptionCodeEnum Status { get; set; }
        public virtual string Info { get; set; }
        public virtual object Data { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual PagedResult PagedResult { get; set; }

        public MessageResponse()
        {
        }

        public MessageResponse(bool isValid, string info, ExceptionCodeEnum status, object data = null)
        {
            IsValid = isValid;
            Status = status;
            Info = info;
            Data = data;
        }
    }
}
