using System.ComponentModel.DataAnnotations;

namespace Camc.MES53.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
