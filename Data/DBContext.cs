using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CQRS.Models;

namespace CQRS.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEvent>().HasKey(sc => new { sc.CategoriesID, sc.EventsID });
        }

        public DbSet<CQRS.Models.Photo> Photos { get; set; }
        public DbSet<CQRS.Models.Category> Categorys { get; set; }
        public DbSet<CQRS.Models.PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<CQRS.Models.Event> Events { get; set; }
        public DbSet<CQRS.Models.Source> Sources { get; set; }
        public DbSet<CQRS.Models.CategoryEvent> CategoryEvent { get; set; }
    }
}
