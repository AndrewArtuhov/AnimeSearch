using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;


namespace Core.Commands.UpdateAnime
{
    public class UpdateAnimeCommand : IRequest
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Season { get; set; }
        public DateTime DateStart { get; set; }
        public TypeAnime Type { get; set; }
        public List<Tag> Tags { get; set; }
        public string Rating { get; set; }
    }
}
