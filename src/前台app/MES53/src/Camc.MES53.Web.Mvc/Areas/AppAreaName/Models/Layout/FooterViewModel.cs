using Camc.MES53.Sessions.Dto;

namespace Camc.MES53.Web.Areas.AppAreaName.Models.Layout
{
    public class FooterViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public bool UseWrapperDiv { get; set; }

        public string GetProductNameWithEdition()
        {
            const string productName = "MES53";

            if (LoginInformations.Tenant == null)
            {
                return productName;
            }

            if (LoginInformations.Tenant.Edition == null)
            {
                return productName;
            }

            if (LoginInformations.Tenant.Edition.DisplayName == null)
            {
                return productName;
            }

            return productName + " " + LoginInformations.Tenant.Edition.DisplayName;
        }
    }
}