using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Tag
    {
        [Key]
        public Guid Guid { get; set; }
        [Display(Name = "Название жанра")]
        public string Name { get; set; }
    }
}
