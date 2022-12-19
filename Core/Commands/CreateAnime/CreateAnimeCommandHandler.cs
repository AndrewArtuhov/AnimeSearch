using Core.Entities;
using Core.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands.CreateAnime
{
    public class CreateAnimeCommandHandler : IRequestHandler<CreateAnimeCommand, Guid>
    {
        private readonly IDbModelContext _animeDbContext;

        public CreateAnimeCommandHandler(IDbModelContext animeDbContext)
        {
            _animeDbContext = animeDbContext;
        }

        public async Task<Guid> Handle(CreateAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = new Anime
            {
                Guid = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                DateStart = request.DateStart,
                Season = request.Season,
                Tags = request.Tags,
                Type = request.Type,
                Rating = request.Rating
            };

            await _animeDbContext.Animes.AddAsync(anime, cancellationToken);
            await _animeDbContext.SaveChangesAsync(cancellationToken);

            return anime.Guid;
        }
    }
}
