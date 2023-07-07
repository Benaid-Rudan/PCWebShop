using Mailjet.Client.Resources;
using PCWebShop.Core.Infrastructure;
using PCWebShop.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace PCWebShop.Core.Interfaces
{
    public interface INarudzbaService
    {
        Task<MessageResponse> AddNarudzba(KorpaVM request, CancellationToken cancellationToken);
    }
}
