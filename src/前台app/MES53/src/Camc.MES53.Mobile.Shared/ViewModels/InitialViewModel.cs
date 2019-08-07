using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Camc.MES53.ApiClient;
using Camc.MES53.Core.Threading;
using Camc.MES53.Models.NavigationMenu;
using Camc.MES53.Services.Navigation;
using Camc.MES53.ViewModels.Base;
using Xamarin.Forms.Internals;

namespace Camc.MES53.ViewModels
{
    public class InitialViewModel : XamarinViewModel
    {
        private readonly IMenuProvider _menuProvider;
        private readonly IApplicationContext _appContext;
        private bool _noAuthorizedMenuItem;

        public bool NoAuthorizedMenuItem
        {
            get => _noAuthorizedMenuItem;
            set
            {
                _noAuthorizedMenuItem = value;
                RaisePropertyChanged(() => NoAuthorizedMenuItem);
            }
        }

        public ICommand PageAppearingCommand => AsyncCommand.Create(SetInitialPageAsync);
        
        public InitialViewModel(IMenuProvider menuProvider, IApplicationContext appContext)
        {
            _menuProvider = menuProvider;
            _appContext = appContext;
        }

        private async Task SetInitialPageAsync()
        {
            var firstAuthorizedMenuItem = GetFirstAuthorizedMenuItemOrNull(out var authorizedMenuItems);

            NoAuthorizedMenuItem = firstAuthorizedMenuItem == null;

            if (firstAuthorizedMenuItem != null)
            {
                await NavigationService.SetDetailPageAsync(firstAuthorizedMenuItem.ViewType);
                SetSelectedMenuItem(authorizedMenuItems, firstAuthorizedMenuItem);
            }
        }

        private NavigationMenuItem GetFirstAuthorizedMenuItemOrNull(out ObservableRangeCollection<NavigationMenuItem> authorizedMenuItems)
        {
            authorizedMenuItems = _menuProvider.GetAuthorizedMenuItems(_appContext.Configuration.Auth.GrantedPermissions);
            var firstMenuItem = authorizedMenuItems.FirstOrDefault();
            if (firstMenuItem?.ViewType == null)
            {
                return null;
            }

            return firstMenuItem;
        }

        private static void SetSelectedMenuItem(IEnumerable<NavigationMenuItem> menuItems, NavigationMenuItem selectedMenuItem)
        {
            menuItems.ForEach(m => m.IsSelected = false);
            selectedMenuItem.IsSelected = true;
        }
    }
}
