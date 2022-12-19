using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Anime
    {
        [Key]
        public Guid Guid { get; set; }
        [Display(Name = "Название аниме")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        [Display(Name = "Сезон")]
        public int Season { get; set; }
        [Display(Name = "Дата начала сезона")]
        public DateTime DateStart { get; set; }
        [Display(Name = "Тип аниме")]
        public TypeAnime Type { get; set; }
        [Display(Name = "Жанр")]
        public List<Tag> Tags { get; set; }
        [Display(Name = "Оценка")]
        public string? Rating { get; set; }
    }
}
