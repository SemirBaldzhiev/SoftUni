using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {

        }
        public MusicHubDbContext([NotNull] DbContextOptions options) 
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongPerformer> SongPerformers { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-F0J1M25\SQLEXPRESS;Database=MusicHub;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SongPerformer>(e =>
            {
                e.HasKey(sp => new { sp.SongId, sp.PerformerId });
            });
        }
    }
}
