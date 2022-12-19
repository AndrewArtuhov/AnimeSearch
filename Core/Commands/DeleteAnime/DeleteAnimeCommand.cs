using MediatR;
using System;

namespace Core.Commands.DeleteAnime
{
    public class DeleteAnimeCommand : IRequest
    {
        public Guid Guid {get;set;}
    }
}
