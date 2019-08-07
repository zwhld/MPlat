using System;
using Camc.MES53.ViewModels.Base;

namespace Camc.MES53.Models.NavigationMenu
{
    public class NavigationMenuItem : ExtendedBindableObject
    {
        private bool _isSelected;

        public string Title { get; set; }

        public string Icon { get; set; }

        public Type ViewType { get; set; }

        public object NavigationParameter { get; set; }

        public string RequiredPermissionName { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                RaisePropertyChanged(() => IsSelected);
            }
        }
    }
}
