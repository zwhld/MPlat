using System;
using Camc.MES53.Core;
using Camc.MES53.Core.Dependency;
using Camc.MES53.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Camc.MES53.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}