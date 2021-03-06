using MyCompanyName.AbpZeroTemplate.Sessions.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Layout
{
    public class FooterViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public bool UseWrapperDiv { get; set; }

        public string GetProductNameWithEdition()
        {
            const string productName = "AbpZeroTemplate";

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