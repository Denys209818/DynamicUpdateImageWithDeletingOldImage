using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogForm.Entities
{
    public class EFContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<TagPost> TagPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=dbblog;Username=userblog;Password=$544idkeuIDOKEKDds(Kdues9dfsuiio$B5rd@dddss542G)K$t!Ube22}xk");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TagPost>(tagPost =>
            {
                tagPost.HasKey(tp => new { tp.PostId, tp.TagId });

                tagPost.HasOne(tp => tp.Tag)
                    .WithMany(t => t.TagPosts)
                    .HasForeignKey(tp => tp.TagId)
                    .IsRequired();

                tagPost.HasOne(tp => tp.Post)
                    .WithMany(t => t.TagPosts)
                    .HasForeignKey(tp => tp.PostId)
                    .IsRequired();
            });
        }
    }
}
