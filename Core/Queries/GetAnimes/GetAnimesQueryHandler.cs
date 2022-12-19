using AutoMapper;
using Core.Common.Exceptions;
using Core.Entities;
using Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Queries.GetAnimes
{
    public class GetAnimesQueryHandler : IRequestHandler<GetAnimesQuery, AnimeVm>
    {
        private readonly IDbModelContext _animeDbContext;
        private readonly IMapper _mapper;

        public GetAnimesQueryHandler(IDbModelContext animeDbContext, IMapper mapper)
        {
           _animeDbContext = animeDbContext;
            _mapper = mapper;
        }

        public async Task<AnimeVm> Handle(GetAnimesQuery request, CancellationToken cancellationToken)
        {
            var entity = await _animeDbContext.Animes.ToListAsync();


            if (entity == null)
            {
                throw new NotFoundException(nameof(Anime));
            }

            return _mapper.Map<AnimeVm>(entity);
        }
    }
}
