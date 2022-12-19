using MediatR;
using System;

namespace Core.Queries.GetAnimeDescription
{
    public  class GetAnimesDescriptionQuery : IRequest<AnimeDescriptionVm>
    {
        public Guid Guid { get; set; }
    }
}
