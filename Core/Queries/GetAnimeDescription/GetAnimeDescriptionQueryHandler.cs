using AutoMapper;
using Core.Common.Exceptions;
using Core.Entities;
using Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Queries.GetAnimeDescription
{
    public class GetAnimeDescriptionQueryHandler : IRequestHandler<GetAnimesDescriptionQuery, AnimeDescriptionVm>
    {
        private readonly IDbModelContext _animeDbContext;
        private readonly IMapper _mapper;

        public GetAnimeDescriptionQueryHandler(IDbModelContext animeDbContext, IMapper mapper)
        {
           _animeDbContext = animeDbContext;
            _mapper = mapper;
        }

        public async Task<AnimeDescriptionVm> Handle(GetAnimesDescriptionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _animeDbContext.Animes.FirstOrDefaultAsync(x => x.Guid == request.Guid, cancellationToken);


            if (entity == null)
            {
                throw new NotFoundException(nameof(Anime), request.Guid);
            }

            return _mapper.Map<AnimeDescriptionVm>(entity);
        }
    }
}
