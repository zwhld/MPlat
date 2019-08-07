using System;
using Camc.MES53.Core;
using Camc.MES53.Localization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Camc.MES53.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return Text;
            }

            return L.Localize(Text);
        }
    }
}