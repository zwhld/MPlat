using System.Threading.Tasks;
using Camc.MES53.Views;
using Xamarin.Forms;

namespace Camc.MES53.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
