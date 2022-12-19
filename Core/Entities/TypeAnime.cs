using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TypeAnime
    {
        [Key]
        public Guid Guid { get; set; }
        [Display(Name = "Тип аниме")]
        public string Name { get; set; }
    }
}
