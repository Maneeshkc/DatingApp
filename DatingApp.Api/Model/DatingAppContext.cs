using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyDatingapp.Api.Model
{
    public partial class DatingAppContext : DbContext
    {
        public DatingAppContext()
        {
        }

        public DatingAppContext(DbContextOptions<DatingAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tuser> Tuser { get; set; }
        public virtual DbSet<TuserPhoto> TuserPhoto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Maneesh-pc;Database=DatingApp;User Id=sa;Password=123mails");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Tuser>(entity =>
            {
                entity.ToTable("TUser");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Interests).IsUnicode(false);

                entity.Property(e => e.Introduction).IsUnicode(false);

                entity.Property(e => e.KnownAs)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastActive).HasColumnType("datetime");

                entity.Property(e => e.LookingFor).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<TuserPhoto>(entity =>
            {
                entity.ToTable("TUserPhoto");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TuserPhoto)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TUserPhoto_TUser");
            });
        }
    }
}
