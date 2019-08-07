using System.Collections.Generic;
using MvvmHelpers;
using Camc.MES53.Models.NavigationMenu;

namespace Camc.MES53.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}