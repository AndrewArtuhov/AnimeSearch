using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Interface
{
    public interface IDbModelContext : IBaseDbContext
    {
        DbSet<Anime> Animes { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<TypeAnime> TypesAnime { get; set; }
    }
}
