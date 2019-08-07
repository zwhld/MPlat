using Abp;

namespace Camc.MES53
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="MES53DomainServiceBase"/>.
    /// For application services inherit MES53AppServiceBase.
    /// </summary>
    public abstract class MES53ServiceBase : AbpServiceBase
    {
        protected MES53ServiceBase()
        {
            LocalizationSourceName = MES53Consts.LocalizationSourceName;
        }
    }
}