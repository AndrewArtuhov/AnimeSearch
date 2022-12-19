using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase.DbContex
{
    public class DbModelContext : DbContext
    { 
        public DbModelContext(DbContextOptions<DbModelContext> options) 
            : base(options) { }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TypeAnime> TypesAnime { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
