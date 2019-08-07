using System.ComponentModel.DataAnnotations;

namespace Camc.MES53.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}