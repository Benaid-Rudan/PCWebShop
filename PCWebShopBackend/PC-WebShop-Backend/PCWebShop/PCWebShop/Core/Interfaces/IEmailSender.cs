using System.Threading.Tasks;

namespace PCWebShop.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}
