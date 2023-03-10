// <auto-generated />
using System;
using DataBase.DbContex;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBase.Migrations
{
    [DbContext(typeof(DbModelContext))]
    [Migration("20221212205629_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Core.Entities.Anime", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .HasColumnType("TEXT");

                    b.Property<int>("Season")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("TypeGuid")
                        .HasColumnType("TEXT");

                    b.HasKey("Guid");

                    b.HasIndex("TypeGuid");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("Core.Entities.Tag", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AnimeGuid")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Guid");

                    b.HasIndex("AnimeGuid");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Core.Entities.TypeAnime", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Guid");

                    b.ToTable("TypesAnime");
                });

            modelBuilder.Entity("Core.Entities.Anime", b =>
                {
                    b.HasOne("Core.Entities.TypeAnime", "Type")
                        .WithMany()
                        .HasForeignKey("TypeGuid");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Core.Entities.Tag", b =>
                {
                    b.HasOne("Core.Entities.Anime", null)
                        .WithMany("Tags")
                        .HasForeignKey("AnimeGuid");
                });

            modelBuilder.Entity("Core.Entities.Anime", b =>
                {
                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
