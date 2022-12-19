using AutoMapper;
using Core.Common.Mapping;
using Core.Entities;
using System;
using System.Collections.Generic;

namespace Core.Queries.GetAnimeDescription
{
    public class AnimeDescriptionVm : IMapWith<Anime>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Season { get; set; }
        public DateTime DateStart { get; set; }
        public TypeAnime Type { get; set; }
        public List<Tag> Tags { get; set; }
        public decimal Rating { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Anime, AnimeVm>()
                .ForMember(vm => vm.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(vm => vm.Season, opt => opt.MapFrom(x => x.Season))
                .ForMember(vm => vm.DateStart, opt => opt.MapFrom(x => x.DateStart))
                .ForMember(vm => vm.Type, opt => opt.MapFrom(x => x.Type))
                .ForMember(vm => vm.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(vm => vm.Rating, opt => opt.MapFrom(x => x.Rating));
        }
    }
}
