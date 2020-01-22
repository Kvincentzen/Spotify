﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spotify.DAL;

namespace Spotify.Migrations
{
    [DbContext(typeof(PlayerContext))]
    partial class PlayerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Spotify.Models.Albums", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtistsID");

                    b.Property<int?>("SongsID");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("ArtistsID");

                    b.HasIndex("SongsID");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Spotify.Models.Artists", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Spotify.Models.Members", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlbumsID");

                    b.Property<int?>("ArtistsID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("AlbumsID");

                    b.HasIndex("ArtistsID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Spotify.Models.Songs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtistsID");

                    b.Property<string>("Title");

                    b.Property<int>("TrackId");

                    b.HasKey("ID");

                    b.HasIndex("ArtistsID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("Spotify.Models.Albums", b =>
                {
                    b.HasOne("Spotify.Models.Artists", "Artists")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistsID");

                    b.HasOne("Spotify.Models.Songs", "Songs")
                        .WithMany()
                        .HasForeignKey("SongsID");
                });

            modelBuilder.Entity("Spotify.Models.Members", b =>
                {
                    b.HasOne("Spotify.Models.Albums", "Albums")
                        .WithMany("Members")
                        .HasForeignKey("AlbumsID");

                    b.HasOne("Spotify.Models.Artists", "Artists")
                        .WithMany("Members")
                        .HasForeignKey("ArtistsID");
                });

            modelBuilder.Entity("Spotify.Models.Songs", b =>
                {
                    b.HasOne("Spotify.Models.Artists", "Artists")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistsID");
                });
#pragma warning restore 612, 618
        }
    }
}
