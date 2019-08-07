namespace Camc.MES53.Authorization.Accounts.Dto
{
    public class ResetPasswordOutput
    {
        public bool CanLogin { get; set; }

        public string UserName { get; set; }
    }
}