namespace Camc.MES53.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}