using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Website.Domain.Entities
{
    public class TextField: EntityBase
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";
    }
}
