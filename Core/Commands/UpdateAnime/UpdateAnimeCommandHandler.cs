using Core.Common.Exceptions;
using Core.Entities;
using Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands.UpdateAnime
{
    public class UpdateAnimeCommandHandler : IRequestHandler<UpdateAnimeCommand>
    {
        private readonly IDbModelContext _animeDbContext;

        public UpdateAnimeCommandHandler(IDbModelContext animeDbContext)
        {
            _animeDbContext = animeDbContext;
        }

        public async Task<Unit> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _animeDbContext.Animes.FirstOrDefaultAsync(x => x.Guid == request.Guid, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Anime), request.Guid);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.DateStart = request.DateStart;
            entity.Season = request.Season;
            entity.Tags = request.Tags;
            entity.Type = request.Type;
            entity.Rating = request.Rating;

            await _animeDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
