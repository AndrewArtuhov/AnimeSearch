using Core.Common.Exceptions;
using Core.Entities;
using Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Commands.DeleteAnime
{
    public class DeleteAnimeCommandHandler : IRequestHandler<DeleteAnimeCommand>
    {
        private readonly IDbModelContext _animeDbContext;

        public DeleteAnimeCommandHandler(IDbModelContext animeDbContext)
        {
            _animeDbContext = animeDbContext;
        }

        public async Task<Unit> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _animeDbContext.Animes.FindAsync(new object[] { request.Guid}, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Anime), request.Guid);
            }

            _animeDbContext.Animes.Remove(entity);
            await _animeDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
